using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySystem : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<HealthManager>().Death += Kill;
    }

    void OnDisable()
    {
        GetComponent<HealthManager>().Death -= Kill;
    }

    void Kill()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 normPos = Camera.main.WorldToViewportPoint(pos);
        if ((normPos.x < 0 || normPos.y > 1 || normPos.x > 1 || normPos.y < 0) && gameObject.tag != "PlayerTag")
        {
            gameObject.SetActive(false);
        }
    }
}
