using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : BaseWeapon, ISmallProjectile
{
    [SerializeField] private GameObject proj;
    private float _projSpeed;

    private void Start()
    {
        _projSpeed = proj.GetComponent<Projectile>().projectileSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Shoot(GameObject proj, float projSpeed)
    {
        GameObject go = Instantiate(proj , firePoint.transform);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward, ForceMode.Impulse);
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            Shoot(proj, _projSpeed);
        }
    }
}
