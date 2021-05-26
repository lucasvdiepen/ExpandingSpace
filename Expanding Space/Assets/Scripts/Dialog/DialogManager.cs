using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public GameObject continueImage;

    public GameObject DialogHolder;

    public float letterDelay = 0.05f;

    private string[] sentences;

    private int sentenceCount = 0;
    private int sentenceLetterCount = 0;

    private bool dialogStarted = false;
    private bool dialogContinue = false;
    private bool dialogEnded = false;

    private float lastLetterTime = 0f;

    PlayerControls playerControls;

    public static DialogManager dialogManager = null;

    private void Awake()
    {
        if(dialogManager == null)
        {
            DontDestroyOnLoad(gameObject);
            dialogManager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerControls = new PlayerControls();

        playerControls.Dialog.ContinueDialog.performed += ctx => ContinueDialog();
    }

    private void OnEnable()
    {
        playerControls.Dialog.Enable();
    }

    private void OnDisable()
    {
        playerControls.Dialog.Disable();
    }

    void Update()
    {
        //Dialog
        if (dialogStarted && dialogContinue && !dialogEnded)
        {
            float time = Time.time;
            if (time >= (lastLetterTime + letterDelay))
            {
                lastLetterTime = time;

                AddLetter(sentences[sentenceCount][sentenceLetterCount].ToString());

                sentenceLetterCount++;
                if (sentenceLetterCount >= sentences[sentenceCount].Length) { sentenceCount++; dialogContinue = false; continueImage.SetActive(true); }

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

    public void ContinueDialog()
    {
        if (dialogEnded) { DialogHolder.SetActive(false); dialogStarted = false; }
        else
        {
            if (!dialogContinue)
            {
                ResetText();
                sentenceLetterCount = 0;
                dialogContinue = true;
                continueImage.SetActive(false);
            }
        }
    }

    public void StartDialog(string[] _sentences)
    {
        if (!dialogStarted)
        {
            sentences = _sentences;
            dialogStarted = true;
            dialogContinue = true;
            dialogEnded = false;
            sentenceCount = 0;
            sentenceLetterCount = 0;
            DialogHolder.SetActive(true);
            continueImage.SetActive(false);
            ResetText();
        }
    }
}
