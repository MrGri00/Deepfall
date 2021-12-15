using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachinePlayer
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(PlayerController controller);
    }
}