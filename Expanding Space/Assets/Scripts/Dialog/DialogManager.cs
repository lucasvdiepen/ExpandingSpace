using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public GameObject continueImage;

    public GameObject dialogHolder;

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

    SoundManager soundManager;

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

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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

                if(!soundManager.dialogTickAudioSource.isPlaying)
                {
                    soundManager.PlayPopupTextSound();
                }

                AddLetter(sentences[sentenceCount][sentenceLetterCount].ToString());

                sentenceLetterCount++;
                if (sentenceLetterCount >= sentences[sentenceCount].Length) 
                { 
                    sentenceCount++; 
                    dialogContinue = false; 
                    continueImage.SetActive(true); 
                    soundManager.StopPopupTextSound();
                }

                if (sentenceCount >= sentences.Length)
                {
                    EndDialog();
                }
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

    public void EndDialog()
    {
        FindObjectOfType<PlayerMovement>().FreezeMovement(false);
        FindObjectOfType<WeaponControls>().ToggleShooting(true);

        dialogEnded = true;
        soundManager.StopPopupTextSound();
    }

    public void ContinueDialog()
    {
        if (dialogEnded) { dialogHolder.SetActive(false); dialogStarted = false; }
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
            FindObjectOfType<PlayerMovement>().FreezeMovement(true);
            FindObjectOfType<WeaponControls>().ToggleShooting(false);
            sentences = _sentences;
            dialogStarted = true;
            dialogContinue = true;
            dialogEnded = false;
            sentenceCount = 0;
            sentenceLetterCount = 0;
            dialogHolder.SetActive(true);
            continueImage.SetActive(false);
            ResetText();
            soundManager.PlayPopupSound();
        }
    }
}
