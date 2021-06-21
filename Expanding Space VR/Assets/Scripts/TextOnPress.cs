using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOnPress : MonoBehaviour
{
    public TextMeshPro textBox;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        anim.Play("ButtonAnimation", 0, 0.25f);
        
    }
}
