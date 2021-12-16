using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUpdater : MonoBehaviour
{
    public static event Action<int, int> UpdateCanvas = delegate { };

    void OnEnable()
    {
        GetComponent<HealthManager>().LifeUpdated += UpdateText;
    }

    void OnDisable()
    {
        GetComponent<HealthManager>().LifeUpdated -= UpdateText;
    }

    void UpdateText(int health, int maxHealth)
    {
        UpdateCanvas(health, maxHealth);
    }
}
