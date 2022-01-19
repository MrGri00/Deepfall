using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupLaser : CollisionSystem
{
    protected override void OnCollision(Collision2D other)
    {
        WeaponSystemData weaponData = Resources.Load<WeaponSystemData>("LaserData");

        Destroy(other.gameObject.GetComponent<WeaponSystem>());

        Laser laser = other.gameObject.AddComponent<Laser>();

        laser.weaponData = weaponData;
        laser.shotPoint = other.gameObject.GetComponent<PlayerController>().shotPoint;

        other.gameObject.GetComponent<PlayerController>()?.SetWeapon(laser);
        other.gameObject.GetComponent<CanvasUpdater>().ReSub(laser);

        GetComponent<HealthManager>().ReduceHealth(1);
    }
}
