using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemLaser : CollisionSystem
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);
    }

    protected override void OnCollision(Collision2D other)
    {
        if (other.gameObject.CompareTag("Solid"))
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        else
        {
            WeaponSystemData wsd = Resources.Load<WeaponSystemData>("Laserdata");
            other.gameObject.GetComponent<HealthManager>()?.ReduceHealth(dmg);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, wsd.fireForce);
        }
    }
}
