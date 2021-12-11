using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; } // 
    public float ver { get; private set; }

    public event Action OnFire = delegate { }; // - CREANDO EL EVENTO - //OnFire puede ser cualquier nombre

    //public event Action DoubleOnFire = delegate { };    //* FUERA

    //public event Action Propeller = delegate { };       //* FUERA
    
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
                
        if (Input.GetButtonDown("Fire1"))
        {
            OnFire();
        }
        /*
        if(ver == -ver)
        {
            Propeller();
        }*/
        
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            DoubleOnFire();
        }

        if (Input.GetKey(KeyCode.W))
        {
            Propeller();
        }*/
    }
}