using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/Slime/Action/Moving")]
public class SlimeMovingAction : StateMachine.Action
{
    public override void Act(FatherController controller)
    {
        controller.SetAnimation("isFalling", false);
    }
}