using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    public AudioSource dialogTickAudioSource;

    public AudioClip dialogPopup;

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
