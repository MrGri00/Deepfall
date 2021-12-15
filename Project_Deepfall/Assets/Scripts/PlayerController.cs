using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public PlayerSwitches _playerSwitches;

    private InputSystemKeyboard _inputSystem;

    private Animator _animatorController;
    private MovementBehaviour _movementBehaviour;

    public StateMachinePlayer.State currentState;

    private void Awake()
    {
        _playerSwitches = GetComponent<PlayerSwitches>();
        _animatorController = GetComponent<Animator>();
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _movementBehaviour = GetComponent<MovementBehaviour>();
    }

    private void Start()
    {
        //ActiveAI = true;
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

    public void SetAnimation(string variable, bool t)
    {
        _animatorController.SetBool(variable, t);
    }

    public void Transition(StateMachinePlayer.State nextState)
    {
        currentState = nextState;
    }
}
