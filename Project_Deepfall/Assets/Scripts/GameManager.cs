using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private MapManager _mapManager;
    [SerializeField]
    private EnemyManager _enemyManager;
    [SerializeField]
    private PowerupManager _powerupManager;

    private void Start()
    {
        
    }
}
