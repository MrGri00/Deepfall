using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableSFX : MonoBehaviour
{
    private AudioSource audioSource = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audioSource.Play();
    }
}
