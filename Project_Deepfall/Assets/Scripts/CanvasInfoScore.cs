using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfoScore : MonoBehaviour
{
    private Text text;

    void OnEnable()
    {
        CanvasUpdater.UpdateCanvasScore += UpdateText;
    }

    void OnDisable()
    {
        CanvasUpdater.UpdateCanvasScore -= UpdateText;
    }

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void UpdateText(int score)
    {
        text.text = score + "";
    }
}
