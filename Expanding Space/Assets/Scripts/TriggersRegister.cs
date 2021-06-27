using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersRegister : MonoBehaviour
{
    private List<ButtonTriggers>triggers = new List<ButtonTriggers>();
    public GameObject[] objectWithTriggers;
    private int allTrue;
    private bool levelCompleted;
    private GameObject apearingDigplace;
    // Start is called before the first frame update
    void Start()
    {
        levelCompleted = false;
        foreach (GameObject obj in objectWithTriggers)
        {
            triggers.Add(obj.GetComponent<ButtonTriggers>());
        }
        apearingDigplace = GameObject.Find("DigPlace");
        apearingDigplace.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        allTrue = 0;
        foreach(ButtonTriggers trigger in triggers)
        {
            if (trigger.isCollected)
            {
                allTrue++;
            }
        }
        if (allTrue == triggers.Count)
        {

            apearingDigplace.SetActive(true);
        }
    }
}
