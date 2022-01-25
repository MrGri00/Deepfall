using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : EnemyController
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (_enemySwitches.PlayerInRange())
            _movementBehaviour.FlyTo(player);
        else
            _movementBehaviour.StopMoving();
    }
}
