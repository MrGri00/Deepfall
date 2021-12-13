using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StateMachine.State currentState;
    public StateMachine.State remainState;

    [HideInInspector]
    public bool isMoving = false;
    [HideInInspector]
    public bool isGrounded = false;

    private Animator _animatorController;
    private InputSystemKeyboard _inputSystem;
    private MovementBehaviour _movementBehaviour;
    private PolygonCollider2D _polygonCollider;

    [SerializeField]
    private LayerMask platformsLayer;

    public bool ActiveAI { get; set; }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _movementBehaviour = GetComponent<MovementBehaviour>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        ActiveAI = true;
    }

    private void OnEnable()
    {
        _inputSystem.Jump += Jump;
        _inputSystem.OnFire += Shoot;
    }

    private void OnDisable()
    {
        _inputSystem.Jump -= Jump;
        _inputSystem.OnFire -= Shoot;
    }

    private void Update()
    {
        Move(_inputSystem.hor);

        if (!ActiveAI) return;

        currentState.UpdateState(this);
    }

    void Move(float hor)
    {
        if (IsMoving(hor))
            _movementBehaviour.Move(hor);
    }

    public bool IsMoving(float axis)
    {
        isMoving = (axis < -0.2 || axis > 0.2);
        return isMoving;
    }

    void Jump()
    {
        if (IsGrounded())
            _movementBehaviour.Jump();
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit;

        //BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask)

        raycastHit = Physics2D.BoxCast(_polygonCollider.bounds.center,
            _polygonCollider.bounds.size, 0f,
            Vector2.down, 0.1f,
            platformsLayer);

        Debug.Log(raycastHit.collider);

        return raycastHit.collider != null;
    }

    void Shoot()
    {

    }

    public void Transition(StateMachine.State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    public void SetAnimation(string animation, bool value)
    {
        _animatorController.SetBool(animation, value);
    }
}
