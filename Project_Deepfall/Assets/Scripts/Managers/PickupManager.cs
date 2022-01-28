using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public float chanceMargin = 30f;

    GameObject pickup = null;

    private int pickupSpawnCoordinateY = -3;
    private float pickupSpawnCoordinateX = 0f;
    private float chance = 0f;
    private int type = 0;

    private void OnEnable()
    {
        MapManager.MapSpawned += PickupSpawn;
    }

    private void OnDisable()
    {
        MapManager.MapSpawned -= PickupSpawn;
    }

    void PickupSpawn()
    {
        chance = UnityEngine.Random.Range(1f, 100f);

        if (chance <= chanceMargin)
        {
            type = UnityEngine.Random.Range(0, 4);

            pickupSpawnCoordinateX = UnityEngine.Random.Range(-4.5f, 4.5f);

            switch (type)
            {
                case 0:
                    pickup = PoolingManager.Instance.GetPooledObject("BlueGemPickup");
                    break;

                case 1:
                    pickup = PoolingManager.Instance.GetPooledObject("GreenGemPickup");
                    break;

                case 2:
                    pickup = PoolingManager.Instance.GetPooledObject("YellowGemPickup");
                    break;

                case 3:
                    pickup = PoolingManager.Instance.GetPooledObject("HealthPickup");
                    break;
            }

            pickup.GetComponent<HealthManager>().ResetHealth();
            pickup.transform.position = new Vector3(pickupSpawnCoordinateX, pickupSpawnCoordinateY, 0);

            pickup.SetActive(true);
        }

        pickupSpawnCoordinateY -= 6;
    }
}
