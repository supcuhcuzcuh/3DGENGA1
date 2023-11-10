using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody _rb;
    private CapsuleCollider _cc;
    private Vector3 defaultGravity = new Vector3(0f, -9.81f, 0f);

    private bool _isJump = false;
    private float _distToGround;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cc = GetComponent<CapsuleCollider>();
        _distToGround = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleJumping();
    }
    
    void HandleJumping()
    {
        if (Input.GetKey(KeyCode.Space) && !_isJump && IsGrounded())
        {
            _isJump = true;
            _rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            Physics.gravity = new Vector3(0f, -200f, 0f);
        }
        else
        {
            _isJump = false;
        }
    }

    bool IsGrounded()
    {
        Debug.Log(Physics.Raycast(transform.position, -Vector3.up, _distToGround));
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround); // returns true if it player hit ground, returns false if in air
    }
}
