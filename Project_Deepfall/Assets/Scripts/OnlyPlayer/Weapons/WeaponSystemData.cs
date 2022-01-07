using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponSystemData")]
public class WeaponSystemData : ScriptableObject
{
    //public GameObject projectile;
    public int fireForce;
    public float cadence;

    public int maxAmmo;
    //public int currentAmmo;

    public float recoil;

    public float bulletLifetime;
}
