using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> ScoreUpdated = delegate { };

    public int score = 0;

    int bestDepth = 0;

    private void Update()
    {
        if ((int)transform.position.y < bestDepth)
        {
            bestDepth = (int)transform.position.y;
            AddScore(1);
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;

        ScoreUpdated(score);
    }
}
