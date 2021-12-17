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

        //transform.position += new Vector3(dir, 0, 0) * speed * Time.deltaTime;

        //_rigidBody.MovePosition((Vector2)transform.position + (new Vector2(dir, 0f) * speed));
        //Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        //_rigidBody.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));

        dir = new Vector2(dir.x, _rigidBody.gravityScale * -1);

        _rigidBody.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    public void Jump()
    {
        //_rigidBody.velocity = Vector2.up * jumpForce;
        _rigidBody.AddForce(Vector2.up * jumpForce);
    }
}
