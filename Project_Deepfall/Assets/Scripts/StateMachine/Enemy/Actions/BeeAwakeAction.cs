using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/Bee/Action/Awake")]
public class BeeAwakeAction : StateMachine.Action
{
    public override void Act(FatherController controller)
    {
        controller.SetAnimation("seesPlayer", true);
    }
}