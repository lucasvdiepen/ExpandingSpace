using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreenHolder;
    public UnityEngine.UI.Button resumeButton;
    public UnityEngine.UI.Button quitButton;

    public GameObject[] checkmarks;

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
        FindObjectOfType<SoundManager>().PlayButtonClickSound();
        FindObjectOfType<GameManager>().ClosePauseScreen();
    }

    public void QuitButtonClicked()
    {
        FindObjectOfType<SoundManager>().PlayButtonClickSound();
        FindObjectOfType<GameManager>().ClosePauseScreen();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenPauseScreen()
    {
        FindObjectOfType<WeaponControls>().ToggleShooting(false);

        pauseScreenHolder.SetActive(true);

        //Set all checkmarks visibility here
        checkmarks[0].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level1Emerald1));
        checkmarks[1].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level1Emerald2));

        checkmarks[2].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level2Emerald1));
        checkmarks[3].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level2Emerald2));

        checkmarks[4].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level3Emerald1));
        checkmarks[5].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level3Emerald2));

        checkmarks[6].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level4Emerald1));
        checkmarks[7].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level4Emerald2));

        checkmarks[8].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level5Emerald1));
        checkmarks[9].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level5Emerald2));

        checkmarks[10].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level6Emerald1));
        checkmarks[11].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level6Emerald2));

        checkmarks[12].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level7Emerald1));
        checkmarks[13].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level7Emerald2));

        checkmarks[14].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level8Emerald1));
        checkmarks[15].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.Level8Emerald2));
    }

    public void ClosePauseScreen()
    {
        FindObjectOfType<WeaponControls>().ToggleShooting(true);

        pauseScreenHolder.SetActive(false);
    }
}
