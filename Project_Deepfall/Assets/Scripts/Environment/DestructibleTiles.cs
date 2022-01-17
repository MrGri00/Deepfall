using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTiles : CollisionSystem
{
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
                    destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(impactPoint), null);

                other.gameObject.GetComponent<HealthManager>()?.ReduceHealth(dmg);
            }
        }
    }
}
