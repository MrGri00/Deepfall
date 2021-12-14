using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Player/Decisions/JumpingDecision")]
public class PlayerJumpingDecision : StateMachine.Decision
{
    public override bool Decide(PlayerController controller)
    {
        return !controller._playerSwitches.GetIsGrounded();
    }
}