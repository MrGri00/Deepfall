using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachinePlayer;

[CreateAssetMenu(menuName = "StateMachinePlayer/Action/Running")]
public class PlayerRunningAction : StateMachinePlayer.Action
{
    public override void Act(PlayerController controller)
    {
        controller.SetAnimation("isJumping", false);
        controller.SetAnimation("isFalling", false);
        controller.SetAnimation("isRunning", true);
    }
}