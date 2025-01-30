using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class UIAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StopClip() => audioSource.Stop();

    public void PlayClip(AudioClip clip, bool isRandomPitch)
    {
        audioSource.pitch = 1f;
        audioSource.clip = clip;
        if (isRandomPitch)  audioSource.pitch = Random.Range(-2f, 2f);
        audioSource.Play();
    }

    public void PlayClip(int index, bool isRandomPitch)
    {
        audioSource.pitch = 1f;
        audioSource.clip = audioClips[index];
        if (isRandomPitch) audioSource.pitch = Random.Range(-2f, 2f);
        audioSource.Play();
    }
}
