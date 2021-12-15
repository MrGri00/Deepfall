using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherController : MonoBehaviour
{
    protected Animator _animatorController;
    protected MovementBehaviour _movementBehaviour;

    public StateMachine.State currentState;

    public void SetAnimation(string variable, bool t)
    {
        _animatorController.SetBool(variable, t);
    }

    public void Transition(StateMachine.State nextState)
    {
        if (nextState != null)
            currentState = nextState;
    }
}
