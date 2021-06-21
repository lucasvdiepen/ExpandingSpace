using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreenHolder;
    public Button resumeButton;
    public Button quitButton;

    public GameObject[] checkmarks;

    public static PauseScreen pauseScreen;

    // Start is called before the first frame update
    private void Awake()
    {
        if (pauseScreen == null)
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
        FindObjectOfType<GameManager>().ClosePauseScreen();
    }

    public void QuitButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenPauseScreen()
    {
        pauseScreenHolder.SetActive(true);

        //Set all checkmarks visibility here
        checkmarks[0].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World1Emerald1));
        checkmarks[1].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World1Emerald2));

        checkmarks[2].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World2Emerald1));
        checkmarks[3].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World2Emerald2));

        checkmarks[4].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World3Emerald1));
        checkmarks[5].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World3Emerald2));

        checkmarks[6].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World4Emerald1));
        checkmarks[7].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World4Emerald2));

        checkmarks[8].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World5Emerald1));
        checkmarks[9].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World5Emerald2));

        checkmarks[10].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World6Emerald1));
        checkmarks[11].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World6Emerald2));

        checkmarks[12].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World7Emerald1));
        checkmarks[13].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World7Emerald2));

        checkmarks[14].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World8Emerald1));
        checkmarks[15].SetActive(FindObjectOfType<Inventory>().HasItem(Inventory.AllItems.World8Emerald2));
    }

    public void ClosePauseScreen()
    {
        pauseScreenHolder.SetActive(false);
    }
}