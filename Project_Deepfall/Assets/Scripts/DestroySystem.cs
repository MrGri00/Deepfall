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
}
