using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticles;

    ParticleSystem p;

    private void OnEnable()
    {
        DestroySystem.PlayParticles += PlayDeathParticles;
    }

    private void OnDisable()
    {
        DestroySystem.PlayParticles += PlayDeathParticles;
    }

    void PlayDeathParticles(Vector3 pos)
    {
        p = Instantiate(deathParticles, pos, Quaternion.identity);

        p.Play();
    }
}
