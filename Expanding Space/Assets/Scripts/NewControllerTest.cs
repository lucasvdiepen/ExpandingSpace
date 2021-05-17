using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewControllerTest : MonoBehaviour
{
    PlayerControls playerControls;

    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Jump.performed += ctx => Jump();

        
    }

    private void Start()
    {
        Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
    }

    public void Jump()
    {
        Debug.Log("Jump button clicked");
    }
}
