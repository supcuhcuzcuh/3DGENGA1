using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    const float crouchSpeed = 40f;
    private float _standingHeight;
    private float _crouchingHeight;
    private CapsuleCollider _cc;
    private Rigidbody _rb;
    private PlayerMovement _pm;
    private bool oneTime = false;
    private void Awake()
    {
        _cc = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
        _pm = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        _standingHeight = transform.localScale.y;
        _crouchingHeight = transform.localScale.y * 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleCrouch();
    }

    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, _crouchingHeight, transform.localScale.z); // change the height according to the _crouchingHeight variable
            _rb.AddForce(Vector3.down, ForceMode.Impulse);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, _standingHeight, transform.localScale.z);
        }
    }
}
