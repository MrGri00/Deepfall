using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event Action Death = delegate { };
    public event Action<int, int> LifeUpdated = delegate { };

    [SerializeField]
    private int maxHealth = 1;

    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private bool isImmortal = false;

    private void Start()
    {
        ResetHealth();
        LifeUpdated(GetHealth(), GetMaxHealth());
    }

    public void ReduceHealth(int dmg)
    {
        if (!isImmortal)
        {
            currentHealth -= dmg;
            LifeUpdated(GetHealth(), GetMaxHealth());
        }

        if (currentHealth <= 0)
            Death();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public int GetHealth()
    {
        if (currentHealth < 0)
            return 0;
        else
            return currentHealth;
    }

    public void AddHealth(int addHealth)
    {
        if ((currentHealth + addHealth) <= maxHealth)
            currentHealth += addHealth;
        else
            ResetHealth();

        LifeUpdated(GetHealth(), GetMaxHealth());
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void AddMaxHealth(int addMaxHealth)
    {
        maxHealth += addMaxHealth;
        ResetHealth();
        LifeUpdated(GetHealth(), GetMaxHealth());
    }
}
