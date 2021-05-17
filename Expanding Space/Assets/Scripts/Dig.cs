using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dig : MonoBehaviour
{
    public float maxVibrationDistance = 1f;
    public float maxDigDistance = 0.5f;

    private bool isNear = false;
    private Vector2 digPosition;

    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Dig.performed += ctx => DigPlace();
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Keyboard.current.fKey.wasPressedThisFrame) DigPlace();

        if (isNear)
        {
            float distanceToDigPlace = Vector2.Distance(transform.position, digPosition);

            Debug.Log("Distance to dig place" + distanceToDigPlace);

            float controllerVibrationStrength = Mathf.Lerp(1, 0, distanceToDigPlace / maxVibrationDistance);

            Debug.Log("Controller vibration strength: " + controllerVibrationStrength);

            Gamepad.current.SetMotorSpeeds(controllerVibrationStrength, controllerVibrationStrength);
        }
    }

    private void DigPlace()
    {
        if (isNear)
        {
            float distanceToDigPlace = Vector2.Distance(transform.position, digPosition);
            if (distanceToDigPlace <= maxDigDistance)
            {
                //Do dig here
                Debug.Log("Dig");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DigPlace")
        {
            Transform digPlaceTransform = collision.GetComponent<Transform>();
            digPosition = digPlaceTransform.position;
            isNear = true;
            InputSystem.ResumeHaptics();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "DigPlace")
        {
            isNear = false;
            InputSystem.PauseHaptics();
        }
    }
}
