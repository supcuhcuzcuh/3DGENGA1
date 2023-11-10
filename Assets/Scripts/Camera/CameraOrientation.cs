using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrientation : MonoBehaviour
{
    [SerializeField] private Camera fpsCam;
    [Header("Camera Settings")]
    [SerializeField] private float mouseSensitivity;

    private float _mouseX;
    private float _horizontalRotation;
    private float _verticalRotation;
    // Update is called once per frame
    void Update()
    {
        HandleCameraOrientation();
    }

    public void HandleCameraOrientation()
    {
        _mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        _horizontalRotation += _mouseX;

        _verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90, 90);

        transform.Rotate(0, _mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(_verticalRotation, _horizontalRotation, 0);
    }
}
