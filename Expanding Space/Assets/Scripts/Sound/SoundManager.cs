using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    public AudioSource dialogTickAudioSource;
    public AudioSource backgroundSource;
    public AudioSource digSounds;

    public AudioClip laser;
    public AudioClip dialogPopup;
    public AudioClip explosion;
    public AudioClip buttonclick;
    public AudioClip itemObtained;

    public void PlayLaserSound()
    {
        sfxAudioSource.volume = 0.1f;
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

    public void PlayDigSound()
    {
        digSounds.Play();
    }

    public void StopDigSound()
    {
        digSounds.Stop();
    }

    public void PlayPopupTextSound()
    {
        dialogTickAudioSource.Play();
    }

    public void StopPopupTextSound()
    {
        dialogTickAudioSource.Stop();
    }
    
    public void PlayGetItemSounds()
    {
        sfxAudioSource.PlayOneShot(itemObtained);;
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