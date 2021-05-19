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

    private void OnApplicationQuit()
    {
        if (IsControllerAvailable()) Gamepad.current.PauseHaptics();
    }

    void Update()
    {
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
            if(IsControllerAvailable())
            {
                Gamepad.current.SetMotorSpeeds(controllerVibrationStrength, controllerVibrationStrength / 2);
            }
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

    private void DigInRange(Vector2 digPlacePosition)
    {
        digPosition = digPlacePosition;
        isNear = true;
        lightSource.gameObject.SetActive(true);
        if(IsControllerAvailable()) InputSystem.ResumeHaptics();
    }

    private void DigOutRange()
    {
        digPosition = Vector2.zero;
        isNear = false;
        lightSource.gameObject.SetActive(false);
        if (IsControllerAvailable()) InputSystem.PauseHaptics();
    }

    private bool IsControllerAvailable()
    {
        if (Gamepad.current == null) return false;
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DigPlace")
        {
            Transform digPlaceTransform = collision.GetComponent<Transform>();
            DigInRange(digPlaceTransform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "DigPlace")
        {
            DigOutRange();
        }
    }
}
