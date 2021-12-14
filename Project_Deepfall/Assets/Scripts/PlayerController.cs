using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StateMachine.State currentState;
    public StateMachine.State remainState;

    [HideInInspector]
    public PlayerSwitches _playerSwitches;

    private Animator _animatorController;
    private InputSystemKeyboard _inputSystem;
    private MovementBehaviour _movementBehaviour;

    public bool ActiveAI { get; set; }

    private void Awake()
    {
        _playerSwitches = GetComponent<PlayerSwitches>();
        _animatorController = GetComponent<Animator>();
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _movementBehaviour = GetComponent<MovementBehaviour>();
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
        Move();

        if (!ActiveAI) return;

        currentState.UpdateState(this);
    }

    void Move()
    {
        if (_playerSwitches.GetIsMoving())
            _movementBehaviour.Move(_inputSystem.hor);
    }

    void Jump()
    {
        if (_playerSwitches.GetIsGrounded())
            _movementBehaviour.Jump();
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
