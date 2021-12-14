using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitches : MonoBehaviour
{
    private bool isMoving = false;
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
        CheckIsMoving(_inputSystem.hor);

        return isMoving;
    }

    public void SetIsMoving(bool t)
    {
        isMoving = t;
    }

    public void CheckIsMoving(float hor)
    {
        SetIsMoving(hor < -0.2 || hor > 0.2);
    }

    public bool GetIsGrounded()
    {
        CheckIsGrounded();

        return isGrounded;
    }

    public void SetIsGrounded(bool t)
    {
        isGrounded = t;
    }

    public void CheckIsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetComponent<PolygonCollider2D>().bounds.center,
            GetComponent<PolygonCollider2D>().bounds.size, 0f,
            Vector2.down, 0.1f,
            platformsLayer);

        Debug.Log(LayerMask.NameToLayer("Platforms"));

        SetIsGrounded(raycastHit.collider != null);
    }
}
