using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText;

    public GameObject DialogHolder;

    public float letterDelay = 0.05f;

    public string[] sentences;

    private int sentenceCount = 0;
    private int sentenceLetterCount = 0;

    private bool dialogStarted = false;
    private bool dialogContinue = false;
    private bool dialogEnded = false;

    private float lastLetterTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {
        //Input

        //Dialog
        if(dialogStarted && dialogContinue && !dialogEnded)
        {
            float time = Time.time;
            if(time >= (lastLetterTime + letterDelay))
            {
                lastLetterTime = time;

                AddLetter(sentences[sentenceCount][sentenceLetterCount].ToString());

                sentenceLetterCount++;
                if (sentenceLetterCount >= sentences[sentenceCount].Length) { sentenceCount++; dialogContinue = false; }

                if (sentenceCount >= sentences.Length) dialogEnded = true;
            }
        }
    }

    private void AddLetter(string letter)
    {
        dialogText.text += letter;
    }

    private void ResetText()
    {
        dialogText.text = "";
    }

    public void Continue()
    {
        if (dialogEnded) DialogHolder.SetActive(false);
        else { ResetText(); dialogContinue = true; }
    }

    public void StartDialog()
    {
        dialogStarted = true;
        dialogContinue = true;
        dialogEnded = false;
        DialogHolder.SetActive(true);
        ResetText();
    }
}
