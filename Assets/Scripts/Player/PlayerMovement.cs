using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera fpsCam;
    [SerializeField] private TMP_Text debugSpeed;

    [Header("Movement Settings")]
    public float moveSpeed;
    public float defaultSpeed;
    [SerializeField] private float sprintSpeed;

    private Rigidbody _rb;
    private float _horizontalInput; // right vector of player
    private float _verticalInput; // forward vector of player
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        debugSpeed.text = "Speed: " + moveSpeed.ToString();
        HandleMovement();
    }

    public void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else moveSpeed = defaultSpeed;

        _horizontalInput = Input.GetAxis("Horizontal"); // 
        _verticalInput = Input.GetAxis("Vertical"); // front vector of player
        Vector3 forwardDir = fpsCam.transform.forward * _verticalInput;
        Vector3 sideDir = fpsCam.transform.right * _horizontalInput;
        Vector3 moveDir = (forwardDir + sideDir).normalized;
        _rb.AddForce(moveDir * moveSpeed);
    }

    public float GetVelocity()
    {
        return _rb.velocity.magnitude;
    }
}
