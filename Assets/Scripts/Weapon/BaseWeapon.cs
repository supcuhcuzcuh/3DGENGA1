using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected int maxAmmo;
}
