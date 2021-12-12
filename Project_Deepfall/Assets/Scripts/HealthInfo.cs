using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthInfo : MonoBehaviour
{
    private Text lifeText;

    void OnEnable()
    {
        CanvasUpdater.UpdateCanvas += UpdateText;
    }

    void OnDisable()
    {
        CanvasUpdater.UpdateCanvas -= UpdateText;
    }

    private void Awake()
    {
        lifeText = GetComponent<Text>();
    }

    private void UpdateText(int lifePoints)
    {
        lifeText.text = "Health: " + lifePoints;
    }
}
