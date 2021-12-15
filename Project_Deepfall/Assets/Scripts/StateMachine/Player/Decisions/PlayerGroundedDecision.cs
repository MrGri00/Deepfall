using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachinePlayer;

[CreateAssetMenu(menuName = "StateMachinePlayer/Decisions/Grounded")]
public class PlayerGroundedDecision : StateMachinePlayer.Decision
{
    public override bool Decide(PlayerController controller)
    {
        return (controller._playerSwitches.GetIsGrounded());
    }
}