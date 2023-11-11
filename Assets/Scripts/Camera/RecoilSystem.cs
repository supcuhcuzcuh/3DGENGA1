using UnityEngine;

public class RecoilSystem : MonoBehaviour
{
    // Rotations
    private Vector3 _currentOrientation;
    private Vector3 _targetOrientation;

    //Hipfire recoil
    [Header("Hipfire recoil settings")]
    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
    [SerializeField] private float recoilZ;

    [SerializeField] private float snapRate;
    [SerializeField] private float returnSpeed;

    // Update is called once per frame
    private void Start()
    {
        _currentOrientation = new Vector3(0f, 90f, 0f);
    }
    void Update()
    {
        _targetOrientation = Vector3.Lerp(_targetOrientation, Vector3.zero, returnSpeed * Time.deltaTime);
        _currentOrientation = Vector3.Slerp(_currentOrientation, _targetOrientation, snapRate * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(_currentOrientation);
        Debug.Log(_currentOrientation);
    }

    public void ActivateRecoil()
    {
        _targetOrientation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
}
