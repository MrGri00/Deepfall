using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/Bee/Action/Sleeping")]
public class BeeSleepingAction : StateMachine.Action
{
    public override void Act(FatherController controller)
    {
        controller.SetAnimation("seesPlayer", false);
    }
}