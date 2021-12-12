using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event Action<bool> Death = delegate { };
    public event Action<int> LifeUpdated = delegate { };

    [SerializeField]
    private int maxHealth = 1;

    [SerializeField]
    private int currentHealth;

    private void Start()
    {
        ResetHealth();
        LifeUpdated(GetHealth());
    }

    public void ReduceHealth(int dmg)
    {
        currentHealth -= dmg;
        LifeUpdated(GetHealth());

        if (currentHealth <= 0)
            Death(false);
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
}
