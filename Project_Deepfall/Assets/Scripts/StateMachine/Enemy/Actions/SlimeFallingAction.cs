using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/Slime/Action/Falling")]
public class SlimeFallingAction : StateMachine.Action
{
    public override void Act(FatherController controller)
    {
        controller.SetAnimation("isFalling", true);
    }
}