using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitches : MonoBehaviour
{
   // private bool isMoving = false;
    private bool isGrounded = false;

    private InputSystemKeyboard _inputSystem;

    [SerializeField]
    private LayerMask platformsLayer;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
    }

    public bool GetIsMoving()
    {
        return (_inputSystem.hor < -0.2 || _inputSystem.hor > 0.2);
    }

    public bool GetIsGrounded()
    {
        CheckIsGrounded();

        return isGrounded;
    }

    public void CheckIsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetComponent<PolygonCollider2D>().bounds.center,
            GetComponent<PolygonCollider2D>().bounds.size, 0f,
            Vector2.down, 0.1f,
            platformsLayer);

        isGrounded = (raycastHit.collider != null);
    }
}
