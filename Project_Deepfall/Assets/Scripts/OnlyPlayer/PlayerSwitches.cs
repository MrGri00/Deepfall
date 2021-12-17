using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitches : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private InputSystemKeyboard _inputSystem;

    [SerializeField]
    private LayerMask platformsLayer;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _inputSystem = GetComponent<InputSystemKeyboard>();
    }

    public bool GetIsMoving()
    {
        return (_inputSystem.movement.x < -0.2f || _inputSystem.movement.x > 0.2f);
        //return (_rigidBody.velocity.x != 0f);
    }

    public bool GetIsJumping()
    {
        //return (_inputSystem.ver > 0.05f);
        return (_rigidBody.velocity.y > 0.2f);
    }

    public bool GetIsFalling()
    {
        return (_rigidBody.velocity.y < 0.2f);
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
