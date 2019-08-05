using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private AudioSource audioClip;

    private void Start()
    {
        audioClip = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D()
    {
        audioClip.Play();
    }
}
