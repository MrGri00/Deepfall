using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTiles : CollisionSystem
{
    public static event Action<Vector3> TileDestroyed = delegate { };

    private Tilemap destructibleTilemap;

    [SerializeField]
    private bool isImmortal = false;

    private void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
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
                    Vector3Int tileToDestroy = destructibleTilemap.WorldToCell(impactPoint);

                    destructibleTilemap.SetTile(tileToDestroy, null);

                    Vector3 eventPos = destructibleTilemap.layoutGrid.CellToWorld(tileToDestroy);

                    TileDestroyed(new Vector3(eventPos.x, transform.position.y, eventPos.z));
                }

                other.gameObject.GetComponent<HealthManager>()?.ReduceHealth(points);
            }
        }
    }
}
