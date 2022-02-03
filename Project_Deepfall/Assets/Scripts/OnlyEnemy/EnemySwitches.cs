using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitches : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D _rigidBody;

    [SerializeField] private LayerMask platformsLayer;

    [SerializeField] private float followDistance = 3;

    private float distance;

    private Vector3 playerOffset;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public bool GetIsFalling()
    {
        return (_rigidBody.velocity.y < -0.2f);
    }

    public bool PlayerInRange()
    {
        playerOffset = player.transform.position - transform.position;
        playerOffset.z = 0;

        distance = playerOffset.magnitude;

        return distance < followDistance;
    }

    public bool GetIsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetComponent<PolygonCollider2D>().bounds.center,
            GetComponent<PolygonCollider2D>().bounds.size, 0f,
            Vector2.down, 0.1f,
            platformsLayer);

        return (raycastHit.collider != null);
    }
}
