using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachinePlayer;

[CreateAssetMenu(menuName = "StateMachinePlayer/Action/Jumping")]
public class PlayerJumpingAction : StateMachinePlayer.Action
{
    public override void Act(PlayerController controller)
    {
        controller.SetAnimation("isJumping", true);
        controller.SetAnimation("isFalling", false);
        controller.SetAnimation("isRunning", false);
    }
}