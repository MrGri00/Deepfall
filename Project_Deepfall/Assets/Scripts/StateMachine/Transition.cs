using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine
{
    [Serializable] //se necesita que se vea en el editor
    public class Transition
    {
        public Decision[] decisions;
        public State trueState;
        public State falseState;
    }
}