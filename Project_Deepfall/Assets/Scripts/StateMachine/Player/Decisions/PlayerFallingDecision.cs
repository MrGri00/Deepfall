using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Falling")]
public class PlayerFallingDecision : StateMachine.Decision
{
    public override bool Decide(FatherController controller)
    {
        PlayerController playerC = (PlayerController)controller;

        return playerC._playerSwitches.GetIsFalling();
    }
}