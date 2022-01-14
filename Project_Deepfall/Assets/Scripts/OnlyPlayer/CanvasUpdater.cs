using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUpdater : MonoBehaviour
{
    public static event Action<int, int> UpdateCanvasLife = delegate { };
    public static event Action<int, int> UpdateCanvasAmmo = delegate { };

    void OnEnable()
    {
        GetComponent<HealthManager>().LifeUpdated += UpdateLife;
        GetComponent<WeaponSystem>().UpdateAmmo += UpdateAmmo;
    }

    void OnDisable()
    {
        GetComponent<HealthManager>().LifeUpdated -= UpdateLife;
        GetComponent<WeaponSystem>().UpdateAmmo -= UpdateAmmo;
    }

    void UpdateLife(int health, int maxHealth)
    {
        UpdateCanvasLife(health, maxHealth);
    }

    void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        UpdateCanvasAmmo(currentAmmo, maxAmmo);
    }
}
