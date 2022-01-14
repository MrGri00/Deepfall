using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfoHealth : MonoBehaviour
{
    private Text text;

    void OnEnable()
    {
        CanvasUpdater.UpdateCanvasLife += UpdateText;
    }

    void OnDisable()
    {
        CanvasUpdater.UpdateCanvasLife -= UpdateText;
    }

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void UpdateText(int health, int maxHealth)
    {
        text.text = health + " / " + maxHealth;
    }
}
