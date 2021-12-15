using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachinePlayer;

[CreateAssetMenu(menuName = "StateMachinePlayer/Action/Falling")]
public class PlayerFallingAction : StateMachinePlayer.Action
{
    public override void Act(PlayerController controller)
    {
        controller.SetAnimation("isJumping", false);
        controller.SetAnimation("isFalling", true);
        controller.SetAnimation("isRunning", false);
    }
}