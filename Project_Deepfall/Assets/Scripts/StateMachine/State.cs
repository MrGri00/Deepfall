using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "StateMachine/State")]
    public class State : ScriptableObject
    {
        public Action[] actions; // en un state se ejecutan varias acciones

        public Transition[] transitions; // Desde un estado se puede pasar a otros estados a través de las transiciones

        public void UpdateState(FatherController controller) // Se ejecutan desde el Controller
        {
            DoActions(controller); // Ejecutamos todas las acciones
            CheckTransitions(controller); // Comprobamos las transiciones
        }

        private void DoActions(FatherController controller) // Ejecuta las acciones
        {
            for(int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(controller); // Llamada al método abstracto
            }
        }

        private bool AllDecisionsTrue(Transition currentTrans, FatherController controller)
        {
            for (int i = 0; i < currentTrans.decisions.Length; i++)
            {
                if (currentTrans.decisions[i].Decide(controller) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void CheckTransitions(FatherController controller)
        {
            for(int i = 0; i < transitions.Length; i++)
            {
                if(AllDecisionsTrue(transitions[i], controller))
                {
                    controller.Transition(transitions[i].trueState);
                    return;
                }
                else
                {
                    controller.Transition(transitions[i].falseState);
                }
            }
        }
    }
}