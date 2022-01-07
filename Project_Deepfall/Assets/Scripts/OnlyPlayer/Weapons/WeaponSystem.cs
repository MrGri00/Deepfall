using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSystem : MonoBehaviour
{
    public WeaponSystemData weaponData;

    public Transform shotPoint;

    private int currentAmmo;

    public abstract void Shoot();
}
