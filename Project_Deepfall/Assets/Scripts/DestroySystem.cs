using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySystem : MonoBehaviour
{
    public static Action<Vector3> PlayParticles = delegate { };

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
        if (gameObject.tag.Equals("Enemy"))
            PlayParticles(gameObject.transform.position);

        gameObject.SetActive(false);
    }
}
