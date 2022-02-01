using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static event Action MapSpawned = delegate { };

    public GameObject player;
    public Transform grid;

    [SerializeField] int renderDistance = 18;

    private int mapSpawnCoordinateY = -6;

    private void Start()
    {
        int rand = 0;

        for (int i = 0; i < 3; i++)
        {
            rand = UnityEngine.Random.Range(1, 7);

            PrintMapSection(rand);
            MapSpawned();
        }
    }

    private void Update()
    {
        int rand = 0;

        if (player.transform.position.y - renderDistance <= mapSpawnCoordinateY)
        {
            rand = UnityEngine.Random.Range(1, 7);

            PrintMapSection(rand);
            MapSpawned();
        }
    }

    void PrintMapSection(int sectionNum)
    {
        GameObject mapSectionBkg = null;
        GameObject mapSectionDest = null;
        GameObject mapSectionSol = null;

        switch (sectionNum)
        {
            case 1:
                mapSectionBkg = PoolingManager.Instance.GetPooledObject("Background1");
                mapSectionDest = PoolingManager.Instance.GetPooledObject("Destructible1");
                mapSectionSol = PoolingManager.Instance.GetPooledObject("Solid1");
                break;

            case 2:
                mapSectionBkg = PoolingManager.Instance.GetPooledObject("Background2");
                mapSectionDest = PoolingManager.Instance.GetPooledObject("Destructible2");
                mapSectionSol = PoolingManager.Instance.GetPooledObject("Solid2");
                break;

            case 3:
                mapSectionBkg = PoolingManager.Instance.GetPooledObject("Background3");
                mapSectionDest = PoolingManager.Instance.GetPooledObject("Destructible3");
                mapSectionSol = PoolingManager.Instance.GetPooledObject("Solid3");
                break;

            case 4:
                mapSectionBkg = PoolingManager.Instance.GetPooledObject("Background4");
                mapSectionDest = PoolingManager.Instance.GetPooledObject("Destructible4");
                mapSectionSol = PoolingManager.Instance.GetPooledObject("Solid4");
                break;

            case 5:
                mapSectionBkg = PoolingManager.Instance.GetPooledObject("Background5");
                mapSectionDest = PoolingManager.Instance.GetPooledObject("Destructible5");
                mapSectionSol = PoolingManager.Instance.GetPooledObject("Solid5");
                break;

            case 6:
                mapSectionBkg = PoolingManager.Instance.GetPooledObject("Background6");
                mapSectionDest = PoolingManager.Instance.GetPooledObject("Destructible6");
                mapSectionSol = PoolingManager.Instance.GetPooledObject("Solid6");
                break;
        }

        if (mapSectionBkg != null)
        {
            mapSectionBkg.transform.position = new Vector3(0, mapSpawnCoordinateY, 0);
            mapSectionBkg.transform.SetParent(grid);
            mapSectionBkg.SetActive(true);
            //mapSectionBkg.GetComponent<TilemapController>().ResetMap();

            mapSectionDest.transform.position = new Vector3(0, mapSpawnCoordinateY, 0);
            mapSectionDest.transform.SetParent(grid);
            mapSectionDest.SetActive(true);
            //mapSectionDest.GetComponent<TilemapController>().ResetMap();

            mapSectionSol.transform.position = new Vector3(0, mapSpawnCoordinateY, 0);
            mapSectionSol.transform.SetParent(grid);
            mapSectionSol.SetActive(true);
            //mapSectionSol.GetComponent<TilemapController>().ResetMap();
        }

        mapSpawnCoordinateY -= 6;
    }
}
