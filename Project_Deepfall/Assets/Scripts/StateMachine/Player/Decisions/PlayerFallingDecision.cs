using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachinePlayer;

[CreateAssetMenu(menuName = "StateMachinePlayer/Decisions/Falling")]
public class PlayerFallingDecision : StateMachinePlayer.Decision
{
    public override bool Decide(PlayerController controller)
    {
        InputSystemKeyboard inputSystem = controller.gameObject.GetComponent<InputSystemKeyboard>();

        return (!controller._playerSwitches.GetIsGrounded() && inputSystem.ver < -0.2f);
    }
}