using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUpdater : MonoBehaviour
{
    public static event Action<int, int> UpdateCanvasLife = delegate { };
    public static event Action<int, int> UpdateCanvasAmmo = delegate { };
    public static event Action<int> UpdateCanvasScore = delegate { };

    HealthManager _healthManager = null;
    ScoreManager _scoreManager = null;
    
    [HideInInspector] public WeaponSystem _weaponSystem = null;

    void OnEnable()
    {
        _healthManager = GetComponent<HealthManager>();
        _healthManager.LifeUpdated += UpdateLife;

        _scoreManager = GetComponent<ScoreManager>();
        _scoreManager.ScoreUpdated += UpdateScore;

        _weaponSystem = GetComponent<WeaponSystem>();
        _weaponSystem.UpdateAmmo += UpdateAmmo;
    }

    void OnDisable()
    {
        _healthManager.LifeUpdated -= UpdateLife;
        _healthManager = null;

        _scoreManager.ScoreUpdated -= UpdateScore;
        _scoreManager = null;

        _weaponSystem.UpdateAmmo -= UpdateAmmo;
        _weaponSystem = null;
    }

    void UpdateLife(int health, int maxHealth)
    {
        UpdateCanvasLife(health, maxHealth);
    }

    void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        UpdateCanvasAmmo(currentAmmo, maxAmmo);
    }

    void UpdateScore(int newScore)
    {
        UpdateCanvasScore(newScore);
    }

    public void ReSub(HealthManager newHealthManager)
    {
        _healthManager.LifeUpdated -= UpdateLife;
        _healthManager = newHealthManager;
        _healthManager.LifeUpdated += UpdateLife;
    }

    public void ReSub(WeaponSystem newWeaponSystem)
    {
        _weaponSystem.UpdateAmmo -= UpdateAmmo;
        _weaponSystem = newWeaponSystem;
        _weaponSystem.UpdateAmmo += UpdateAmmo;
    }
}
