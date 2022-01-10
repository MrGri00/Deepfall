using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : FatherController
{
    [HideInInspector]
    public EnemySwitches _enemySwitches;

    private void Awake()
    {
        _enemySwitches = GetComponent<EnemySwitches>();
        _animatorController = GetComponent<Animator>();
        _movementBehaviour = GetComponent<MovementBehaviour>();
    }
}
