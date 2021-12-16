using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    [SerializeField]
    private int dmg = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);
    }

    protected virtual void OnCollision(Collision2D other)
    {
        other.gameObject.GetComponent<HealthManager>().ReduceHealth(dmg);
    }
}
