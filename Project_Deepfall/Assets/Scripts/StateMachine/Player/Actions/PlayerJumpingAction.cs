using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Player/Action/Jumping")]
public class PlayerJumpingAction : StateMachine.Action
{
    public override void Act(FatherController controller)
    {
        controller.SetAnimation("isJumping", true);
        controller.SetAnimation("isFalling", false);
        controller.SetAnimation("isRunning", false);
    }
}