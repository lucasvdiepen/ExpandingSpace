using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dig : MonoBehaviour
{
    public float maxIndicatorDistance = 1f;
    public float maxDigDistance = 0.5f;

    public float minVibrationStrength = 0f;
    public float maxVibrationStrength = 0.5f;

    PlayerControls playerControls;

    private static AntenneLighting antenneLighting;

    private class DigPlaceInfo
    {
        public bool isNear { get; private set; }
        public Vector2 position { get; private set; }
        public DigPlace script { get; private set; }

        public void SetDigPlace(Vector2 _position, DigPlace _script)
        {
            isNear = true;
            position = _position;
            script = _script;

            antenneLighting.EnableLight();

            if (IsControllerAvailable()) InputSystem.ResumeHaptics();
        }

        public bool isDug()
        {
            return script.isDug;
        }

        public void Reset()
        {
            isNear = false;
            position = Vector2.zero;
            script = null;

            antenneLighting.DisableLight();

            if (IsControllerAvailable()) InputSystem.ResumeHaptics();
        }
    }

    private DigPlaceInfo digInfo = new DigPlaceInfo();

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
        antenneLighting = GetComponent<AntenneLighting>();
    }

    private void OnApplicationQuit()
    {
        if (IsControllerAvailable()) Gamepad.current.PauseHaptics();
    }

    void Update()
    {
        if (digInfo.isNear)
        {
            //Get distance between player and dig place
            float distanceToDigPlace = Vector2.Distance(transform.position, digInfo.position);

            //Calculate vibration strength
            float controllerVibrationStrength = Mathf.Lerp(maxVibrationStrength, minVibrationStrength, distanceToDigPlace / maxIndicatorDistance);

            //Calculate light source strength
            float lightSourceStrength = Mathf.Lerp(1f, 0f, distanceToDigPlace / maxIndicatorDistance);

            //Set light source intensity
            antenneLighting.SetBrightness((int)(lightSourceStrength * 100));

            //Set vibration
            if(IsControllerAvailable())
            {
                Gamepad.current.SetMotorSpeeds(controllerVibrationStrength, controllerVibrationStrength / 2);
            }
        }
    }

    private void DigPlace()
    {
        if (digInfo.isNear)
        {
            float distanceToDigPlace = Vector2.Distance(transform.position, digInfo.position);
            if (distanceToDigPlace <= maxDigDistance)
            {
                //Do dig here
                Debug.Log("Dig");
            }
        }
    }

    private void DigInRange(Vector2 digPlacePosition, DigPlace script)
    {
        digInfo.SetDigPlace(digPlacePosition, script);
    }

    private void DigOutRange()
    {
        digInfo.Reset();
    }

    private static bool IsControllerAvailable()
    {
        if (Gamepad.current == null) return false;
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DigPlace")
        {
            Transform digPlaceTransform = collision.GetComponent<Transform>();
            DigInRange(digPlaceTransform.position, collision.GetComponent<DigPlace>());
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
