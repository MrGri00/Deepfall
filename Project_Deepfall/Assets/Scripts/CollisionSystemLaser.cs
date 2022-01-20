using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemLaser : CollisionSystem
{
    protected override void OnCollision(Collision2D other)
    {
        if (other.gameObject.CompareTag("Solid"))
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * Resources.Load<WeaponSystemData>("LaserData").fireForce);
        }
        else
        {
            //WeaponSystemData wsd = Resources.Load<WeaponSystemData>("Laserdata");
            other.gameObject.GetComponent<HealthManager>()?.ReduceHealth(points);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * Resources.Load<WeaponSystemData>("LaserData").fireForce);
        }
    }
}
