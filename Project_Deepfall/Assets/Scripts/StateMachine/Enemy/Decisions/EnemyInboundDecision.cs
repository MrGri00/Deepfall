using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/Decisions/Inbound")]
public class EnemyInboundDecision : StateMachine.Decision
{
    public override bool Decide(FatherController controller)
    {
        EnemyController enemyC = (EnemyController)controller;

        return enemyC._enemySwitches.PlayerInRange();
    }
}