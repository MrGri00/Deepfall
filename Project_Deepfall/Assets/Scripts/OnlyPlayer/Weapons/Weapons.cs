using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    protected float cadence;

    protected int maxAmmo;
    protected int currentAmmo;

    protected float recoil;

    protected float bulletLifetime;

    public virtual void Shoot() { }
}
