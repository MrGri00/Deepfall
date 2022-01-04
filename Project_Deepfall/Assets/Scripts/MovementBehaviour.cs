using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D _rigidBody;

    private float lastDir = 1;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {

    }

    public void Move(Vector2 dir)
    {
        if (dir.x * lastDir < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lastDir = dir.x;
        }

        _rigidBody.velocity = new Vector2(dir.x * speed, _rigidBody.velocity.y);
    }

    public void Jump()
    {
        _rigidBody.velocity = Vector2.up * jumpForce;
    }
}
