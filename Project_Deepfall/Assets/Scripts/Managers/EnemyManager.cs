using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int enemySpawnCoordinateY = -3;
    private void OnEnable()
    {
        MapManager.MapSpawned += EnemySpawn;
    }

    private void OnDisable()
    {
        MapManager.MapSpawned -= EnemySpawn;
    }

    void EnemySpawn()
    {
        GameObject enemy = PoolingManager.Instance.GetPooledObject("Slime");

        float rand = UnityEngine.Random.Range(-4.5f, 4.5f);

        enemy.GetComponent<HealthManager>().ResetHealth();
        enemy.transform.position = new Vector3(rand, enemySpawnCoordinateY, 0);

        enemy.SetActive(true);

        enemySpawnCoordinateY -= 6;
    }
}
