using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponSystem
{
    public override void Shoot()
    {
        GameObject projectile = PoolingManager.Instance.GetPooledObject("Bullet");

        projectile.GetComponent<HealthManager>().ResetHealth();

        if (projectile != null)
        {
            projectile.transform.position = shotPoint.position;
            projectile.transform.rotation = shotPoint.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * weaponData.fireForce);
        }
    }
}
