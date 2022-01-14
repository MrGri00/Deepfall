using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfoAmmo : MonoBehaviour
{
    private Text text;

    void OnEnable()
    {
        CanvasUpdater.UpdateCanvasAmmo += UpdateText;
    }

    void OnDisable()
    {
        CanvasUpdater.UpdateCanvasAmmo -= UpdateText;
    }

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void UpdateText(int ammo, int maxAmmo)
    {
        text.text = ammo + " / " + maxAmmo;
    }
}
