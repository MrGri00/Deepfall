using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDestroy : MonoBehaviour
{
    [SerializeField]
    private float distanceFromCameraX = 1;
    [SerializeField]
    private float distanceFromCameraY = 1;

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 normPos = Camera.main.WorldToViewportPoint(pos);

        if (normPos.x < (distanceFromCameraX - 1) * -1 || normPos.x > distanceFromCameraX || 
            normPos.y < (distanceFromCameraY - 1) * -1 || normPos.y > distanceFromCameraY)
        {
            gameObject.SetActive(false);
        }
    }
}
