using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool inRange = false;
    private string[] sentencesInRange = null;

    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Dialog.StartDialog.performed += ctx => StartDialog();
    }

    private void OnEnable()
    {
        playerControls.Dialog.Enable();
    }

    private void OnDisable()
    {
        playerControls.Dialog.Disable();
    }

    private void StartDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(sentencesInRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dialog")
        {
            Dialog dialogScript = collision.GetComponent<Dialog>();
            sentencesInRange = dialogScript.sentences;
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Dialog")
        {
            inRange = false;
            sentencesInRange = null;
        }
    }
}
