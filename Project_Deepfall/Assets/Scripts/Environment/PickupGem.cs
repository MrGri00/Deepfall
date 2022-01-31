using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGem : CollisionSystem
{
    protected override void OnCollision(Collision2D other)
    {
        other.gameObject.GetComponent<ScoreManager>()?.AddScore(score);

        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<HealthManager>().ReduceHealth(GetComponent<HealthManager>().GetMaxHealth());
        }
    }
}
