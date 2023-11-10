using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    protected int max;
    protected float fireRate;

    public abstract void SetUp(int maxAmmo, float firingRate);
}
