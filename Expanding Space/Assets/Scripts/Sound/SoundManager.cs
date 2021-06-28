using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioClip jump;

    public float laserVolume;
    public float jumpVolume = 0.3f;

    private void OnLevelWasLoaded(int level)
    {
        Scene loadedScene = SceneManager.GetSceneByBuildIndex(level);
        if(loadedScene.name == "TravelGame")
        {
            if (backgroundSource.isPlaying) backgroundSource.Stop();
        }
        else
        {
            if (!backgroundSource.isPlaying) backgroundSource.Play();
        }
    }

    public void PlayLaserSound()
    {
        sfxAudioSource.volume = laserVolume;
        sfxAudioSource.PlayOneShot(laser);
        sfxAudioSource.volume = 1.0f;
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
        sfxAudioSource.PlayOneShot(itemObtained);
    }

    public void PlayJumpSound()
    {
        sfxAudioSource.volume = jumpVolume;
        sfxAudioSource.PlayOneShot(jump);
        sfxAudioSource.volume = 1f;
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