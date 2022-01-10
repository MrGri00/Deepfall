using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponSystemData")]
public class WeaponSystemData : ScriptableObject
{
    public int fireForce;
    public float cadence;

    public int maxAmmo;

    public float recoil;

    public float bulletLifetime;
}
