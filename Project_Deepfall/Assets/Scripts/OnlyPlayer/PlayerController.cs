using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FatherController
{
    public Transform shotPoint;

    [HideInInspector]
    public PlayerSwitches _playerSwitches;

    [SerializeField]
    private WeaponSystem _currentWeapon;

    private InputSystemKeyboard _inputSystem;

    private void Awake()
    {
        _playerSwitches = GetComponent<PlayerSwitches>();
        _animatorController = GetComponent<Animator>();
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _movementBehaviour = GetComponent<MovementBehaviour>();
        _currentWeapon = GetComponent<WeaponSystem>();
    }

    private void OnEnable()
    {
        _inputSystem.OnFire += Shoot;
    }

    private void OnDisable()
    {
        _inputSystem.OnFire -= Shoot;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        Jump();
        Move();
    }

    void Move()
    {
        if (_playerSwitches.GetIsMoving())
            _movementBehaviour.Move(_inputSystem.movement);
    }

    void Jump()
    {
        if (_playerSwitches.GetIsGrounded() && _playerSwitches.GetIsJumping())
            _movementBehaviour.Jump();
    }

    void Shoot()
    {
        if (!_playerSwitches.GetIsGrounded())
            _currentWeapon.Shoot();
    }
}
