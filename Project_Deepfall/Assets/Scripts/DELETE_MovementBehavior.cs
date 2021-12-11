using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DELETE_MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Vector3 _direction;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        rb.MovePosition(transform.position + _direction * _speed * Time.fixedDeltaTime);
    }

    public void Move(Vector3 dir)
    {
        rb.MovePosition(transform.position + dir * _speed * Time.fixedDeltaTime);
    }

    public void MovePosition(float x, float y, float z)
    {
        transform.position += new Vector3(x, y, z);
    }

    public void Move(float x, float y)
    {
        Vector3 dir = new Vector3(x, y, 0);
        rb.MovePosition(transform.position + dir * _speed * Time.fixedDeltaTime);
    }
}
