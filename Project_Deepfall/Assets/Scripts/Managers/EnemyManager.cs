using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float chanceMargin = 70f;

    private GameObject enemy = null;

    private int enemySpawnCoordinateY = -3;
    private float enemySpawnCoordinateX = 0;

    private bool enemyType = false;

    private float chance = 0f;

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
        chance = UnityEngine.Random.Range(1f, 100f);

        if (chance <= chanceMargin)
        {
            enemySpawnCoordinateX = UnityEngine.Random.Range(-4.5f, 4.5f);

            enemyType = Random.value < 0.5f;

            switch (enemyType)
            {
                case true:
                    enemy = PoolingManager.Instance.GetPooledObject("Slime");
                    break;

                case false:
                    enemy = PoolingManager.Instance.GetPooledObject("Bee");
                    break;
            }

            enemy.GetComponent<HealthManager>().ResetHealth();
            enemy.transform.position = new Vector3(enemySpawnCoordinateX, enemySpawnCoordinateY, 0);

            enemy.SetActive(true);
        }

        enemySpawnCoordinateY -= 6;
    }
}
