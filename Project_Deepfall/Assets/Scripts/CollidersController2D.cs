using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersController2D : MonoBehaviour
{

    private SpriteRenderer _spr;
    private Sprite _currentSprite;

    private void Start()
    {
        _spr = GetComponent<SpriteRenderer>();
        _currentSprite = _spr.sprite;
    }

    private void Update()
    {
        if (_spr.sprite.name != _currentSprite.name)
        {
            _currentSprite = _spr.sprite;
            PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            polygonCollider.pathCount = sprite.GetPhysicsShapeCount();

            List<Vector2> path = new List<Vector2>();
            for (int i = 0; i < polygonCollider.pathCount; i++)
            {
                path.Clear();
                sprite.GetPhysicsShape(i, path);
                polygonCollider.SetPath(i, path.ToArray());
            }
        }
    }
}
