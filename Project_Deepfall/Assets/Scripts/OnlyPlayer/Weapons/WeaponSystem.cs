using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSystem : MonoBehaviour
{
    public WeaponSystemData weaponData;

    public Transform shotPoint;

    protected int currentAmmo;

    public abstract void Shoot();
}
