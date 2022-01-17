using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    [SerializeField]
    private WeaponSystemData weaponData;

    private void OnEnable()
    {
        StartCoroutine(LifetimeCountdown());
    }

    private IEnumerator LifetimeCountdown()
    {
        yield return new WaitForSeconds(weaponData.bulletLifetime);
        gameObject.SetActive(false);
    }
}
