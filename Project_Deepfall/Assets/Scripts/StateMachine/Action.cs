using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachinePlayer
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(PlayerController controller);
    }
}