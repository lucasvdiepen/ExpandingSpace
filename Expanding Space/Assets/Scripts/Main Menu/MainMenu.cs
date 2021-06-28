using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject butttons;

    public GameObject settingsButtons;

    public Animator mainCamera;


    public void Play()
    {
        Debug.Log("Play the Game");

        SceneManager.LoadScene(FindObjectOfType<SaveManager>().GetPlanet().ToString());
    }

    public void Options()
    {
        StartCoroutine(OptionsWait());
    } 

    public void Quit()
    {
        Debug.Log("Quit Game");
        // Quits game
        Application.Quit();
    }

    public void ToMainMenu()
    {
        StartCoroutine(ToMainMenuWait());
    }

    public IEnumerator OptionsWait()
    {
        butttons.SetActive(false);

        mainCamera.SetTrigger("ZoomInToPlanet");

        yield return new WaitForSeconds(1.6f);

        settingsButtons.SetActive(true);
    }

    public IEnumerator ToMainMenuWait()
    {
        settingsButtons.SetActive(false);
        mainCamera.SetTrigger("ZoomOutOfPlanet");

        yield return new WaitForSeconds(1.6f);

        butttons.SetActive(true);
        
    }
}
