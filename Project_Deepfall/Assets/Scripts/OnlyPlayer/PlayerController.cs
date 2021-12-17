using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FatherController
{
    [HideInInspector]
    public PlayerSwitches _playerSwitches;

    private InputSystemKeyboard _inputSystem;

    private void Awake()
    {
        _playerSwitches = GetComponent<PlayerSwitches>();
        _animatorController = GetComponent<Animator>();
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _movementBehaviour = GetComponent<MovementBehaviour>();
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
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //if (_playerSwitches.GetIsMoving())
            _movementBehaviour.Move(_inputSystem.movement);
    }

    void Jump()
    {
        if (_playerSwitches.GetIsGrounded())
            _movementBehaviour.Jump();
    }

    void Shoot()
    {

    }
}
