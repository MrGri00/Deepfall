using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : WeaponSystem
{
    public override event Action<int, int> UpdateAmmo = delegate { };

    public override void Shoot()
    {
        GameObject projectile = PoolingManager.Instance.GetPooledObject("Ray");

        _rigidBody = GetComponent<Rigidbody2D>();

        if (projectile != null && canShoot && currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmo(currentAmmo, weaponData.maxAmmo);
            projectile.GetComponent<HealthManager>().ResetHealth();
            projectile.transform.position = shotPoint.position;
            projectile.transform.rotation = shotPoint.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * weaponData.fireForce);
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(transform.up * weaponData.recoil);
            StartCoroutine(CadenceCountdown());
        }
    }

    public override IEnumerator CadenceCountdown()
    {
        canShoot = false;
        yield return new WaitForSeconds(weaponData.cadence);
        canShoot = true;
    }

    public override void Reload()
    {
        currentAmmo = weaponData.maxAmmo;
        UpdateAmmo(currentAmmo, weaponData.maxAmmo);
    }
}
