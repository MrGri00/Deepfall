using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    public static event Action<int> AddCollisionScore = delegate { };

    [SerializeField]
    protected int points = 1;

    [SerializeField]
    protected int score = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);

        if (!collision.gameObject.CompareTag("Solid"))
            AddCollisionScore(score);
    }

    protected virtual void OnCollision(Collision2D other)
    {
        other.gameObject.GetComponent<HealthManager>()?.ReduceHealth(points);
    }
}
