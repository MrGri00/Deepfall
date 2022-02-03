using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public float chanceMargin = 20f;

    GameObject powerup = null;

    private int powerupSpawnCoordinateY = -3;
    private float powerupSpawnCoordinateX = 0f;
    private float chance = 0f;
    private int type = 0;

    private Vector3 powerupFinalPosition;

    private void OnEnable()
    {
        MapManager.MapSpawned += PowerupSpawn;
    }

    private void OnDisable()
    {
        MapManager.MapSpawned -= PowerupSpawn;
    }

    void PowerupSpawn()
    {
        chance = UnityEngine.Random.Range(1f, 100f);

        if (chance <= chanceMargin)
        {
            type = UnityEngine.Random.Range(0, 4);

            powerupSpawnCoordinateX = UnityEngine.Random.Range(-4.5f, 4.5f);

            switch (type)
            {
                case 0:
                    powerup = PoolingManager.Instance.GetPooledObject("GunPowerup");
                    break;

                case 1:
                    powerup = PoolingManager.Instance.GetPooledObject("ShotgunPowerup");
                    break;

                case 2:
                    powerup = PoolingManager.Instance.GetPooledObject("LaserPowerup");
                    break;

                case 3:
                    powerup = PoolingManager.Instance.GetPooledObject("HealthPowerup");
                    break;
            }

            powerup.GetComponent<HealthManager>().ResetHealth();

            powerupFinalPosition.x = powerupSpawnCoordinateX;
            powerupFinalPosition.y = powerupSpawnCoordinateY;
            powerupFinalPosition.z = 0;

            powerup.transform.position = powerupFinalPosition;

            powerup.SetActive(true);
        }

        powerupSpawnCoordinateY -= 6;
    }
}
