using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponSystem
{
    public override event Action<int, int> UpdateAmmo = delegate { };

    public override void Shoot()
    {
        GameObject[] projectile = new GameObject[weaponData.maxAmmo * 5];

        _rigidBody = GetComponent<Rigidbody2D>();

        for (int i = 0; i < 5; i++)
        {
            projectile[i] = PoolingManager.Instance.GetPooledObject("Slug");

            if (projectile[i] != null && canShoot && currentAmmo > 0)
            {
                projectile[i].GetComponent<HealthManager>().ResetHealth();
                projectile[i].transform.position = shotPoint.position;

                float rand = UnityEngine.Random.Range(-50, 50);

                projectile[i].transform.rotation = new Quaternion(
                    shotPoint.rotation.x, 
                    shotPoint.rotation.y, 
                    shotPoint.rotation.z + rand, 
                    shotPoint.rotation.w);

                projectile[i].SetActive(true);
                projectile[i].GetComponent<Rigidbody2D>().AddForce(transform.up * weaponData.fireForce);
            }
        }

        if (currentAmmo > 0 && canShoot)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(transform.up * weaponData.recoil);

            currentAmmo--;
            UpdateAmmo(currentAmmo, weaponData.maxAmmo);

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
