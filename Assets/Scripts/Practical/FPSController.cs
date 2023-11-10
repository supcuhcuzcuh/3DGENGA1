using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private AmmoManager _am;
    [SerializeField] private CameraControl cm;
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    //private CharacterController controller;
    private Rigidbody _rb;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //controller = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
        HandleCameraRotation();
        HandleShooting();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 
        float verticalInput = Input.GetAxis("Vertical"); // front vector of player\
        Vector3 forwardDir = cam.transform.forward * verticalInput;
        Vector3 sideDir = cam.transform.right * horizontalInput;
        Vector3 moveDir = (forwardDir + sideDir).normalized;
        _rb.AddForce(moveDir * moveSpeed);
    }

    private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalRotation += mouseX;

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        cm.Shake();
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1000))
        {
            Crate c = hit.transform.GetComponent<Crate>();
            if (c == null)
            {
                return; 
            }
            c.OnDamaged(10);
        }
    }
}