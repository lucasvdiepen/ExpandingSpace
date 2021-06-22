using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public UnityEngine.UI.Button[] planetButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        for(int i = 0; i < planetButtons.Length; i++)
        {
            AddOnclickListener(i);
        }

        /*planet1Button.onClick.AddListener(() => PlanetClicked(1));
        planet2Button.onClick.AddListener(() => PlanetClicked(2));
        planet3Button.onClick.AddListener(() => PlanetClicked(3));
        planet4Button.onClick.AddListener(() => PlanetClicked(4));
        planet5Button.onClick.AddListener(() => PlanetClicked(5));
        planet6Button.onClick.AddListener(() => PlanetClicked(6));
        planet7Button.onClick.AddListener(() => PlanetClicked(7));
        planet8Button.onClick.AddListener(() => PlanetClicked(8));
        planet9Button.onClick.AddListener(() => PlanetClicked(9));*/
    }

    private void OnDisable()
    {
        for (int i = 0; i < planetButtons.Length; i++)
        {
            planetButtons[i].onClick.RemoveAllListeners();
        }

        /*planet1Button.onClick.RemoveAllListeners();
        planet2Button.onClick.RemoveAllListeners();
        planet3Button.onClick.RemoveAllListeners();
        planet4Button.onClick.RemoveAllListeners();
        planet5Button.onClick.RemoveAllListeners();
        planet6Button.onClick.RemoveAllListeners();
        planet7Button.onClick.RemoveAllListeners();
        planet8Button.onClick.RemoveAllListeners();
        planet9Button.onClick.RemoveAllListeners();*/
    }

    public void AddOnclickListener(int i)
    {
        planetButtons[i].onClick.AddListener(() => PlanetClicked(i + 1));
    }

    private void PlanetClicked(int planetId)
    {
        Debug.Log("Planet clicked " + planetId);
    }
}
