using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Player/Action/Idle")]
public class PlayerIdleAction : StateMachine.Action
{
    public override void Act(PlayerController controller)
    {
        controller.SetAnimation("isJumping", false);
        controller.SetAnimation("isFalling", false);
        controller.SetAnimation("isRunning", false);
    }
}