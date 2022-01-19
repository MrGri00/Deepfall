using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShotgun : CollisionSystem
{
    protected override void OnCollision(Collision2D other)
    {
        WeaponSystemData weaponData = Resources.Load<WeaponSystemData>("ShotgunData");

        Destroy(other.gameObject.GetComponent<WeaponSystem>());

        Shotgun shotgun = other.gameObject.AddComponent<Shotgun>();

        shotgun.weaponData = weaponData;
        shotgun.shotPoint = other.gameObject.GetComponent<PlayerController>().shotPoint;

        other.gameObject.GetComponent<PlayerController>()?.SetWeapon(shotgun);
        other.gameObject.GetComponent<CanvasUpdater>().ReSub(shotgun);

        GetComponent<HealthManager>().ReduceHealth(1);
    }
}
