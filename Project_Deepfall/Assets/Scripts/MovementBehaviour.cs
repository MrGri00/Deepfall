using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private InputSystemKeyboard _inputSystem = null;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
    }
}
