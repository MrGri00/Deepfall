using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapons
{
    private void Awake()
    {
        cadence = 1f;
        maxAmmo = 12;
        currentAmmo = maxAmmo;
        recoil = 1f;
        bulletLifetime = 3f;
    }

    public override void Shoot()
    {
        
    }
}
