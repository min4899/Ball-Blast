using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}
