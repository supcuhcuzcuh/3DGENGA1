using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 2f;
    private float _xRotate;
    private float _yRotate;
    private float _zRotate;

    private CameraOrientation _co;
    private void Start()
    {
        _co = GetComponent<CameraOrientation>();
    }

    public void Shake()
    {
        StartCoroutine(ShakeCamera(5f, 5f));
    }

    IEnumerator ShakeCamera(float inDuration, float inStrength)
    {
        _co.HandleCameraOrientation();
        _shakeDuration = inDuration;
        Quaternion startRotation = transform.localRotation;
        float elapsedTime = 0.0f;
        Debug.Log("SHAKING CAMERA");
        while (elapsedTime < inDuration)
        {
            elapsedTime += Time.deltaTime;
            var strength = inStrength * Mathf.Lerp(1, 0, elapsedTime / inDuration);
            // Implement the camera shake function by changing the x, y, z position randomly
            _xRotate = _xRotate += Random.Range(-1, 1) * strength;
            _yRotate = _yRotate += Random.Range(-1, 1) * strength;
            _zRotate = _zRotate += Random.Range(-1, 1) * strength;
            transform.localRotation = Quaternion.Euler(new Vector3(
                 Random.Range(-2, 2),
                 Random.Range(-2, 2),
                 Random.Range(-2, 2))
            );
            yield return null;
        }
        transform.localRotation = startRotation;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shake();
        }
    }
}
