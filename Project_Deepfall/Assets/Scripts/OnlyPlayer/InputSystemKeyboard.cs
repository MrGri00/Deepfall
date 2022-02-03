using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    [NonSerialized]
    public Vector2 movement;

    public event Action PauseGame = delegate { };
    public event Action OnFire = delegate { };

    [HideInInspector]
    public bool isPaused = false;

    void Update()
    {
        if (!isPaused)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Escape))
                PauseGame();

            if (Input.GetButtonDown("Fire1"))
                OnFire();
        }
    }
}