using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;

    public void Move()
    {

    }

    public void Move(float dir)
    {
        transform.position += new Vector3(dir, 0, 0) * speed * Time.fixedDeltaTime;
    }
}
