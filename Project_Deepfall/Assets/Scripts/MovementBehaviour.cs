using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;

    private float lastDir = 1;

    public void Move()
    {

    }

    public void Move(float dir)
    {
        if (dir * lastDir < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lastDir = dir;
        }

        transform.position += new Vector3(dir, 0, 0) * speed * Time.fixedDeltaTime;
    }
}
