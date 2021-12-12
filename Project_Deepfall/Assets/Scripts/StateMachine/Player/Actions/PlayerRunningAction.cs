using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Player/Action/Running")]
public class PlayerRunningAction : StateMachine.Action
{
    public override void Act(PlayerController controller)
    {
        controller.SetAnimation("isJumping", false);
        controller.SetAnimation("isFalling", false);
        controller.SetAnimation("isRunning", true);
    }
}