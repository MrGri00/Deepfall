using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachinePlayer;

[CreateAssetMenu(menuName = "StateMachinePlayer/Decisions/Jumping")]
public class PlayerJumpingDecision : StateMachinePlayer.Decision
{
    public override bool Decide(PlayerController controller)
    {
        InputSystemKeyboard inputSystem = controller.gameObject.GetComponent<InputSystemKeyboard>();

        return (!controller._playerSwitches.GetIsGrounded() && inputSystem.ver > 0.2f);
    }
}