using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public float chanceMargin = 30f;

    GameObject pickup = null;

    private float chance = 0f;
    private int type = 0;

    private void OnEnable()
    {
        TilemapController.TileDestroyed += PickupSpawn;
    }

    private void OnDisable()
    {
        TilemapController.TileDestroyed -= PickupSpawn;
    }

    void PickupSpawn(Vector3 spawnPos)
    {
        chance = UnityEngine.Random.Range(1f, 100f);

        if (chance <= chanceMargin)
        {
            type = UnityEngine.Random.Range(0, 4);

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
            pickup.transform.position = spawnPos;

            pickup.SetActive(true);
        }
    }
}
