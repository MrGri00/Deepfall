using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : EnemyController
{
    private void Update()
    {
        if (_enemySwitches.GetIsGrounded())
            _movementBehaviour.Move();
    }
}
