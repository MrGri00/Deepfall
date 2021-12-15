using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Player/Decisions/Running")]
public class PlayerRunningDecision : StateMachine.Decision
{
    public override bool Decide(FatherController controller)
    {
        PlayerController playerC = (PlayerController)controller;

        return playerC._playerSwitches.GetIsMoving();
    }
}