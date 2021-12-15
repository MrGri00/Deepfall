using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Player/Action/Falling")]
public class PlayerFallingAction : StateMachine.Action
{
    public override void Act(FatherController controller)
    {
        controller.SetAnimation("isJumping", false);
        controller.SetAnimation("isFalling", true);
        controller.SetAnimation("isRunning", false);
    }
}