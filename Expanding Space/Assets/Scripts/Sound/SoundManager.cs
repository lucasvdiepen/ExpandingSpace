using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    public AudioSource dialogTickAudioSource;
    public AudioSource backgroundSource;

    public AudioClip laser;
    public AudioClip dialogPopup;
    public AudioClip explosion;
    public AudioClip buttonclick;

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

    public void PlayButtonClickSound()
    {
        sfxAudioSource.PlayOneShot(buttonclick);
    }
    public void SetBackgroundVolume(float volume)
    {
        
        backgroundSource.volume = volume;
    }
}
