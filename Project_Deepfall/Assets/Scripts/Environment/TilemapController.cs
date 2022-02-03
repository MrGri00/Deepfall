using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : CollisionSystem
{
    public static event Action<Vector3> TileDestroyed = delegate { };

    private Tilemap tilemap;

    [SerializeField]
    private bool isImmortal = false;

    List<SavedTile> originalMap = new List<SavedTile>();

    struct SavedTile
    {
        public Vector3Int tilePosition;
        public TileBase tileType;
    }

    private Vector3 positionExchange;

    private SavedTile sT = new SavedTile();

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        SaveMap();
    }

    protected override void OnCollision(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Vector3 impactPoint = Vector3.zero;

            foreach (ContactPoint2D hit in other.contacts)
            {
                impactPoint.x = hit.point.x - 0.01f * hit.normal.x;
                impactPoint.y = hit.point.y - 0.01f * hit.normal.y;

                if (!isImmortal)
                {
                    Vector3Int tileToDestroy = tilemap.WorldToCell(impactPoint);

                    tilemap.SetTile(tileToDestroy, null);

                    Vector3 eventPos = tilemap.layoutGrid.CellToWorld(tileToDestroy);

                    positionExchange.x = eventPos.x;
                    positionExchange.y = transform.position.y;
                    positionExchange.z = eventPos.z;

                    TileDestroyed(positionExchange);
                }

                other.gameObject.GetComponent<HealthManager>()?.ReduceHealth(points);
            }
        }
    }

    public void ResetMap()
    {
        foreach (SavedTile sT in originalMap)
        {
            tilemap.SetTile(sT.tilePosition, sT.tileType);
        }
    }

    private void SaveMap()
    {
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                sT.tilePosition = pos;
                sT.tileType = tilemap.GetTile(pos);

                originalMap.Add(sT);
            }
        }
    }
}
