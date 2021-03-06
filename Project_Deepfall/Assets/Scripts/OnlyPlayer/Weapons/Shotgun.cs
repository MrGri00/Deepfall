using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponSystem
{
    [SerializeField]
    private int slugsPerShot = 5;

    [SerializeField]
    private float shotgunFan = 20;

    public override event Action<int, int> UpdateAmmo = delegate { };

    private Quaternion rotation;

    private float rand;

    private Vector2 velocityExchange;

    public override void Shoot()
    {
        GameObject[] projectile = new GameObject[slugsPerShot];

        _rigidBody = GetComponent<Rigidbody2D>();

        for (int i = 0; i < slugsPerShot; i++)
        {
            projectile[i] = PoolingManager.Instance.GetPooledObject("Slug");

            if (projectile[i] != null && canShoot && currentAmmo > 0)
            {
                projectile[i].GetComponent<HealthManager>().ResetHealth();
                projectile[i].transform.position = shotPoint.position;

                rand = UnityEngine.Random.Range(-shotgunFan, shotgunFan);

                rotation = Quaternion.Euler(
                    shotPoint.eulerAngles.x,
                    shotPoint.eulerAngles.y,
                    shotPoint.eulerAngles.z + rand);

                projectile[i].transform.rotation = rotation;

                projectile[i].SetActive(true);
                projectile[i].GetComponent<Rigidbody2D>().AddForce(projectile[i].transform.up * weaponData.fireForce);
            }
        }

        if (currentAmmo > 0 && canShoot)
        {
            velocityExchange.x = _rigidBody.velocity.x;
            velocityExchange.y = 0;
            _rigidBody.velocity = velocityExchange;

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
