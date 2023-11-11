using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseWeapon, ISmallProjectile, IRecoil
{
    public RecoilSystem rc => GameObject.Find("Cam Pivot").GetComponent<RecoilSystem>();

    public void Shoot(GameObject proj, float projSpeed)
    {
        GameObject go = Instantiate(proj, firePoint.transform.position, proj.transform.localRotation);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * proj.GetComponent<Projectile>().projectileSpeed, ForceMode.Impulse);
        rc.ActivateRecoil();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(proj, proj.GetComponent<Projectile>().projectileSpeed);
        }
    }
}
