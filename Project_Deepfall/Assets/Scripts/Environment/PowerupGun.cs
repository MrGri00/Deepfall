using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGun : CollisionSystem
{
    protected override void OnCollision(Collision2D other)
    {
        WeaponSystemData weaponData = Resources.Load<WeaponSystemData>("GunData");

        Destroy(other.gameObject.GetComponent<WeaponSystem>());

        Gun gun = other.gameObject.AddComponent<Gun>();

        gun.weaponData = weaponData;
        gun.shotPoint = other.gameObject.GetComponent<PlayerController>().shotPoint;

        other.gameObject.GetComponent<PlayerController>()?.SetWeapon(gun);

        // TESTING AREA
        other.gameObject.GetComponent<CanvasUpdater>().ReSub(gun);
        other.gameObject.SetActive(false);
        other.gameObject.SetActive(true);
        // TESTING AREA

        GetComponent<HealthManager>().ReduceHealth(1);
    }
}
