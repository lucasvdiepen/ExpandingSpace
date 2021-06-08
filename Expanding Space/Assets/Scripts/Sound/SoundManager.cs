using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    public AudioSource dialogTickAudioSource;

    public AudioClip laser;
    public AudioClip dialogPopup;
    public AudioClip explosion;

    public void PlayLaserSound()
    {
        sfxAudioSource.PlayOneShot(laser);
    }

    public void PlayExplosionSound()
    {
        sfxAudioSource.PlayOneShot(explosion);
    }

    public void PlayPopupSound()
    {
        sfxAudioSource.PlayOneShot(dialogPopup);
    }

    public void PlayPopupTextSound()
    {
        dialogTickAudioSource.Play();
    }

    public void StopPopupTextSound()
    {
        dialogTickAudioSource.Stop();
    }
}
