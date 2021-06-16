using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOnPress : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    private void showText()
    {
        if (textBox.enabled)
            textBox.enabled = false;
        else if (textBox.enabled == false)
            textBox.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
