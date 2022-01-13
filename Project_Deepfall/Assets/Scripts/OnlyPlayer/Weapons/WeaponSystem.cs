using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSystem : MonoBehaviour
{
    public WeaponSystemData weaponData;

    public Transform shotPoint;

    protected int currentAmmo;
    protected bool canShoot = true;

    protected Rigidbody2D _rigidBody;

    public abstract void Shoot();

    public abstract void InitializeWeapon();

    public abstract IEnumerator CadenceCountdown();
}
