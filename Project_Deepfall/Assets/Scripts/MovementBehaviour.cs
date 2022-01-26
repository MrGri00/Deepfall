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

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        if (WallInFront())
            lastDir *= -1;

        _rigidBody.velocity = new Vector2(lastDir * speed, _rigidBody.velocity.y);
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

    public void FlyTo(GameObject target)
    {
        Vector2 playerOffset;

        playerOffset = target.transform.position - transform.position;

        playerOffset = playerOffset.normalized;

        _rigidBody.velocity = playerOffset * speed;
    }

    public void StopMoving()
    {
        _rigidBody.velocity = new Vector2(0, 0);
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
