using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private LayerMask platformsLayer;

    public float speed;
    public float jumpForce;

    private Rigidbody2D _rigidBody;

    private float lastDir = 1;

    private Vector2 velocityExchange;
    private Vector3 scaleExchange;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        if (WallInFront())
            lastDir *= -1;

        velocityExchange.x = lastDir * speed;
        velocityExchange.y = _rigidBody.velocity.y;
        _rigidBody.velocity = velocityExchange;
    }

    public void Move(Vector2 dir)
    {
        if (dir.x * lastDir < 0)
        {
            scaleExchange.x = -transform.localScale.x;
            scaleExchange.y = transform.localScale.y;
            scaleExchange.z = transform.localScale.z;

            transform.localScale = scaleExchange;
            lastDir = dir.x;
        }

        velocityExchange.x = dir.x * speed;
        velocityExchange.y = _rigidBody.velocity.y;
        _rigidBody.velocity = velocityExchange;
    }

    public void Jump()
    {
        _rigidBody.velocity = Vector2.up * jumpForce;
    }

    public void FlyTo(GameObject target)
    {
        Vector2 playerOffset;

        playerOffset = target.transform.position - transform.position;

        playerOffset = playerOffset.normalized;

        _rigidBody.velocity = playerOffset * speed;
    }

    public void StopMoving()
    {
        velocityExchange.x = 0;
        velocityExchange.y = 0;
        _rigidBody.velocity = velocityExchange;
    }

    private bool WallInFront()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetComponent<PolygonCollider2D>().bounds.center,
            GetComponent<PolygonCollider2D>().bounds.size, 0f,
            Vector2.right, 0.1f,
            platformsLayer);

        return raycastHit.collider != null;
    }
}
