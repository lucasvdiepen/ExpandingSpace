using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dig : MonoBehaviour
{
    public Light lightSource;

    public float maxIndicatorDistance = 1f;
    public float maxDigDistance = 0.5f;

    public float minVibrationStrength = 0f;
    public float maxVibrationStrength = 0.5f;

    public float minLightSourceStrength = 0f;
    public float maxLightSourceStrength = 1f;

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
            //Get distance between player and dig place
            float distanceToDigPlace = Vector2.Distance(transform.position, digPosition);

            //Calculate vibration strength
            float controllerVibrationStrength = Mathf.Lerp(maxVibrationStrength, minVibrationStrength, distanceToDigPlace / maxIndicatorDistance);

            //Calculate light source strength
            float lightSourceStrength = Mathf.Lerp(maxLightSourceStrength, minLightSourceStrength, distanceToDigPlace / maxIndicatorDistance);

            //Set light source intensity
            lightSource.intensity = lightSourceStrength;

            //Set vibration
            Gamepad.current.SetMotorSpeeds(controllerVibrationStrength, controllerVibrationStrength / 2);
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
            lightSource.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "DigPlace")
        {
            isNear = false;
            InputSystem.PauseHaptics();
            lightSource.gameObject.SetActive(false);
        }
    }
}
