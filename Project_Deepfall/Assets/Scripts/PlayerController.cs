using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StateMachine.State currentState;
    public StateMachine.State remainState;

    private Animator _animatorController;
    private InputSystemKeyboard _inputSystem;
    private MovementBehaviour _movementBehaviour;

    [HideInInspector]
    public bool isMoving = false;

    public bool ActiveAI { get; set; }

    private void Awake()
    {
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
        _inputSystem.OnFire += Shoot;
    }

    private void OnDisable()
    {
        _inputSystem.OnFire -= Shoot;
    }

    private void Update()
    {
        if (_inputSystem.hor != 0)
        {
            isMoving = true;
            _movementBehaviour.Move(_inputSystem.hor);
        }
        else
            isMoving = false;

        if (!ActiveAI) return;

        currentState.UpdateState(this);
    }

    public void Transition(StateMachine.State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    void Shoot()
    {

    }

    public void SetAnimation(string animation, bool value)
    {
        _animatorController.SetBool(animation, value);
    }
}
