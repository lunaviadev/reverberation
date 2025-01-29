using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]

    public AudioClip respawn;
    public AudioClip createClone;
    public AudioClip destroyClone;
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip die;
    public AudioClip command1;
    public AudioClip command2;
    public AudioClip command3;
    public AudioClip command4;
    public AudioClip command5;
    public AudioClip command6;


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}



