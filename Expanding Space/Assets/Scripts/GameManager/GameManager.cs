using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    PlayerControls playerControls;

    [HideInInspector] public bool isPaused = false;

    private void Awake()
    {
        if (gameManager == null)
        {
            Debug.Log("Dont destroy game object");
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else DestroyImmediate(gameObject);

        playerControls = new PlayerControls();

        playerControls.UI.Pause.performed += ctx => Pause();
    }

    private void OnEnable()
    {
        playerControls.UI.Enable();
    }

    private void OnDisable()
    {
        playerControls.UI.Disable();
    }

    public void Pause()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (isPaused) ClosePauseScreen();
            else OpenPauseScreen();
        }
    }

    public void OpenPauseScreen()
    {
        if(!FindObjectOfType<MapManager>().mapCanvas.activeSelf)
        {
            Time.timeScale = 0f;
            isPaused = true;
            FindObjectOfType<PauseScreen>().OpenPauseScreen();
        }
    }

    public void ClosePauseScreen()
    {
        Time.timeScale = 1f;
        isPaused = false;
        FindObjectOfType<PauseScreen>().ClosePauseScreen();
    }
}
