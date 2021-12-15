using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(FatherController controller);
    }
}