using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystemKeyboard _inputSystem;
    private MovementBehaviour _movementBehaviour;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _movementBehaviour = GetComponent<MovementBehaviour>();
    }

    private void OnEnable()
    {
        _inputSystem.OnFire += Shoot;
    }

    private void OnDisable()
    {
        _inputSystem.OnFire -= Shoot;
    }

    private void Update()
    {
        if (_inputSystem.hor != 0)
            _movementBehaviour.Move(_inputSystem.hor);
    }

    void Shoot()
    {

    }
}
