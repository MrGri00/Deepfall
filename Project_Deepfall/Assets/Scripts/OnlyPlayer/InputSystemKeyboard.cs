using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    //public float hor { get; private set; }
    //public float ver { get; private set; }

    public Vector2 movement;

    //public event Action Jump = delegate { };
    public event Action OnFire = delegate { };

    void Update()
    {
        //hor = Input.GetAxis("Horizontal");
        //ver = Input.GetAxis("Vertical");

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //if (Input.GetKeyDown(KeyCode.W))
        //    Jump();

        if (Input.GetButtonDown("Fire1"))
            OnFire();
    }
}