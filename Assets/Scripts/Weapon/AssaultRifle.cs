using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : BaseWeapon, ISmallProjectile
{
   // [SerializeField] private GameObject proj;
    public void Shoot(GameObject proj, float projSpeed) // implemented interface 
    {
        GameObject go = Instantiate(proj, firePoint.transform.position, Quaternion.identity); 
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * proj.GetComponent<Projectile>().projectileSpeed, ForceMode.Impulse);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            Shoot(proj, proj.GetComponent<Projectile>().projectileSpeed);
        }
    }
}
