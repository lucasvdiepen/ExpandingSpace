using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Butttons;

    public Animator mainCamera;
    public void Play()
    {
        Debug.Log("Play the Game");
    }

    public void Options()
    {
        Debug.Log("Go to Options");
        Butttons.SetActive(false);

        mainCamera.SetTrigger("ZoomInToPlanet");
    } 

    public void Quit()
    {
        Debug.Log("Quit Game");
        // Quits game
        Application.Quit();
    }

}
