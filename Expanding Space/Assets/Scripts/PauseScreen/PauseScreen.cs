using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreenHolder;
    public Button resumeButton;
    public Button quitButton;

    public static PauseScreen pauseScreen;

    // Start is called before the first frame update
    private void Awake()
    {
        if(pauseScreen == null)
        {
            DontDestroyOnLoad(gameObject);
            pauseScreen = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        resumeButton.onClick.AddListener(ResumeButtonClicked);
        quitButton.onClick.AddListener(QuitButtonClicked);
    }

    private void OnDisable()
    {
        resumeButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }

    public void ResumeButtonClicked()
    {

    }

    public void QuitButtonClicked()
    {

    }

    public void OpenPauseScreen()
    {
        pauseScreenHolder.SetActive(true);
    }

    public void ClosePauseScreen()
    {
        pauseScreenHolder.SetActive(false);
    }
}
