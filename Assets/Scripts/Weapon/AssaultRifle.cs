using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : BaseWeapon
{
    [SerializeField] private int maxAmmo;
    [SerializeField] private float firingRate;

    private void Start()
    {
        SetUp(maxAmmo, firingRate);
    }
    public override void SetUp(int maxAmmo, float firingRate)
    {
        this.maxAmmo = maxAmmo;
        this.firingRate = firingRate;
    }
}
