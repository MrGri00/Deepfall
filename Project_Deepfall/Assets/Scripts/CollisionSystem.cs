using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    [SerializeField]
    private int dmg = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision(collision);
    }

    protected virtual void OnCollision(Collider2D other)
    {
        other.gameObject.GetComponent<HealthManager>().ReduceHealth(dmg);
    }
}
