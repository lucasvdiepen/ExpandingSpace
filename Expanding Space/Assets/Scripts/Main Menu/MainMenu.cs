using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play the Game");
    }

    public void Options()
    {
        Debug.Log("Go to Options");
    } 
    public void Quit()
    {
        Debug.Log("Quit Game");
        // Quits game
        Application.Quit();
    }

}
