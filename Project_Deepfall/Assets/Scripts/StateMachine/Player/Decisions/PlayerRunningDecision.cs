using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachinePlayer;

[CreateAssetMenu(menuName = "StateMachinePlayer/Decisions/Running")]
public class PlayerRunningDecision : StateMachinePlayer.Decision
{
    public override bool Decide(PlayerController controller)
    {
        return controller._playerSwitches.GetIsMoving();
    }
}