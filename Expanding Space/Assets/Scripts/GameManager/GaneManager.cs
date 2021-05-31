using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaneManager : MonoBehaviour
{
    public static GameManager gameManager;

    PlayerControls playerControls;

    bool isPaused = false;

    private void Awake()
    {


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
        if (isPaused) ClosePauseScreen();
        else OpenPauseScreen();
    }

    public void OpenPauseScreen()
    {
        Time.timeScale = 0f;
        isPaused = true;
        FindObjectOfType<PauseScreen>().OpenPauseScreen();
    }

    public void ClosePauseScreen()
    {
        Time.timeScale = 1f;
        isPaused = false;
        FindObjectOfType<PauseScreen>().ClosePauseScreen();
    }
}
