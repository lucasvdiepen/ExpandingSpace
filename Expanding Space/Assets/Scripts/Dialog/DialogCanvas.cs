using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCanvas : MonoBehaviour
{
    public static DialogCanvas dialogCanvas;

    private void Awake()
    {
        if (dialogCanvas == null)
        {
            dialogCanvas = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
