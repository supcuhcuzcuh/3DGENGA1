using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SniperRifle : BaseWeapon
{
    [SerializeField] private int maxAmmo;
    [SerializeField] private float firingRate;
    public override void SetUp(int maxAmmo, float firingRate)
    {
        this.maxAmmo = maxAmmo;
        this.firingRate = firingRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUp(maxAmmo, firingRate);  
    }
}
