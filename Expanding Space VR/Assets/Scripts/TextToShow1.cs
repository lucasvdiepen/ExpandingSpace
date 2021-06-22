using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextToShow1 : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    void Start()
    {
        displayText.text = "";
    }

    void Update()
    {

    }

    public void DisplayText1()
    {
        displayText.text = "1";
    }
}
