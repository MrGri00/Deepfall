using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Player/Decisions/RunningDecision")]
public class PlayerRunningDecision : StateMachine.Decision
{
    public override bool Decide(PlayerController controller)
    {
        bool t = controller.isMoving;
        return t;
    }
}