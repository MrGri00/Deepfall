using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class Controller : MonoBehaviour
    {
        public State currentState; // apuntador al estado actual
        public State remainState;  // el estado en el que te quedas si no pasas a la siguiente
        public bool ActiveAI { get; set; }

        private Animator _animatorController;
        //private HealthSystem _healtSystem;

        private void Awake()
        {
            _animatorController = GetComponent<Animator>();
            //_healtSystem = GetComponent<HealthSystem>();
        }

        public void Start()
        {
            ActiveAI = true; // Para activar la IA
        }

        public void Update() // Se ejecutan las acciones del estado actual.
        {
            if (!ActiveAI)                   // El parámetro permite que los 
                return;                      // estados tengan una referencia al
            //currentState.UpdateState(this);  // controlador, para poder llamar a
                                             // sus métodos
        }

        //public int GetCurrentHealth()
        //{
        //    return _healtSystem.GetHealth();
        //}

        public void SetAnimation(string animation, bool value)
        {
            _animatorController.SetBool(animation, value);
        }

        public void Transition(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
            }
        }
    }
}