using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHealth : CollisionSystem
{
    protected override void OnCollision(Collision2D other)
    {
        other.gameObject.GetComponent<HealthManager>()?.AddMaxHealth(points);

        if (other.gameObject.CompareTag("Player"))
            GetComponent<HealthManager>().ReduceHealth(GetComponent<HealthManager>().GetMaxHealth());
    }
}
