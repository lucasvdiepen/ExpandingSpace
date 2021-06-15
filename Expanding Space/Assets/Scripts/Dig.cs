using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dig : MonoBehaviour
{
    public GameObject pointer;

    public float maxIndicatorDistance = 1f;
    public float maxDigDistance = 0.5f;

    public float minVibrationStrength = 0f;
    public float maxVibrationStrength = 0.5f;

    public float rotationTime = 0.75f;
    private bool isRotating = false;
    private float rotatingTimeElapsed = 0;
    private Vector3 newRotation;
    private Vector3 oldRotation;

    private bool movingToPosition = false;
    private Vector3 digOldPosition = Vector3.zero;
    private Vector3 digPosition = Vector3.zero;
    private float digMoveTime = 0f;
    private float movingTimeElapsed = 0;

    public float digDownDepth = 1f;
    public float digMovingTime = 2f;

    private bool isDigging = false;

    public ParticleSystem dirt;

    PlayerControls playerControls;

    private Collider2D collider;

    private static AntenneLighting antenneLighting;

    private class DigPlaceInfo
    {
        public bool isNear { get; private set; }
        public Vector2 position { get; private set; }
        public Vector3 rotation { get; private set; }
        private DigPlace script { get; set; }

        public void SetDigPlace(Vector2 _position, Vector3 _rotation, DigPlace _script)
        {
            isNear = true;
            position = _position;
            rotation = _rotation;
            script = _script;

            antenneLighting.EnableLight();

            if (IsControllerAvailable()) InputSystem.ResumeHaptics();
        }

        public bool isDug()
        {
            if (script != null) return script.isDug;

            return false;
        }

        public void Reset()
        {
            isNear = false;
            position = Vector2.zero;
            script = null;

            antenneLighting.DisableLight();

            if (IsControllerAvailable()) InputSystem.ResumeHaptics();
        }

        public void Dig()
        {
            script.Dig();
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
        collider = GetComponent<Collider2D>();
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

        if(isRotating)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Lerp(oldRotation.z, newRotation.z, rotatingTimeElapsed / rotationTime));

            if(rotatingTimeElapsed >= rotationTime)
            {
                isRotating = false;
            }

            rotatingTimeElapsed += Time.deltaTime;
        }

        if (movingToPosition)
        {
            transform.position = Vector3.Lerp(digOldPosition, digPosition, movingTimeElapsed / digMoveTime);

            if (movingTimeElapsed >= digMoveTime)
            {
                movingToPosition = false;
            }

            movingTimeElapsed += Time.deltaTime;
        }
    }

    public void RotatePlayerWithDigPlace(Vector3 rotation)
    {
        oldRotation = transform.rotation.eulerAngles;
        newRotation = rotation;
        rotatingTimeElapsed = 0;
        isRotating = true;
    }

    public IEnumerator DigLoot(Transform digPlacePosition)
    {
        if (!isDigging)
        {
            dirt.Play();

            isDigging = true;

            FindObjectOfType<PlayerMovement>().FreezeMovement(true);
            collider.enabled = false;
            pointer.SetActive(false);

            //Move to center
            MoveToPosition(digPlacePosition.position, 0.4f);

            //Move down animation here

            //Move down
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(new Vector3(digPlacePosition.position.x, digPlacePosition.position.y - digDownDepth, digPlacePosition.position.z), 1.5f);

            //Move up animation here

            //Move up
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(digPlacePosition.position, 1f);

            yield return new WaitUntil(() => !movingToPosition);

            collider.enabled = true;
            pointer.SetActive(true);
            FindObjectOfType<PlayerMovement>().FreezeMovement(false);

            isDigging = false;

            dirt.Stop();
        }
    }

    public IEnumerator DigTeleport(Transform digPlacePosition, Transform digEndPlacePosition)
    {
        if (!isDigging)
        {
            dirt.Play();

            isDigging = true;

            FindObjectOfType<PlayerMovement>().FreezeMovement(true);
            collider.enabled = false;
            pointer.SetActive(false);

            //Move to center
            MoveToPosition(digPlacePosition.position, 0.4f);

            //Rotate
            RotatePlayerWithDigPlace(digPlacePosition.rotation.eulerAngles);

            // Move down animation here

            //Move down
            yield return new WaitUntil(() => !movingToPosition && !isRotating);

            MoveToPosition(new Vector3(digPlacePosition.position.x, digPlacePosition.position.y - digDownDepth, digPlacePosition.position.z), 1f);

            yield return new WaitUntil(() => !movingToPosition);

            dirt.Stop();

            //Set position of player to end dig place
            transform.position = new Vector3(digEndPlacePosition.position.x, digEndPlacePosition.position.y - digDownDepth, digEndPlacePosition.position.z);

            //Set rotation to end dig place
            transform.rotation = digEndPlacePosition.rotation;

            //Move up animation here

            //Move up
            yield return new WaitForSeconds(digMovingTime);

            dirt.Play();

            MoveToPosition(new Vector3(digEndPlacePosition.position.x, digEndPlacePosition.position.y, digEndPlacePosition.position.z), 1f);

            yield return new WaitUntil(() => !movingToPosition);

            collider.enabled = true;
            pointer.SetActive(true);
            FindObjectOfType<PlayerMovement>().FreezeMovement(false);

            isDigging = false;

            dirt.Stop();
        }
    }

    public void MoveToPosition(Vector3 position, float moveTime)
    {
        movingTimeElapsed = 0;
        movingToPosition = true;
        digPosition = position;
        digOldPosition = transform.position;
        digMoveTime = moveTime;
    }

    private void DigPlace()
    {
        if (digInfo.isNear && !digInfo.isDug())
        {
            float distanceToDigPlace = Vector2.Distance(transform.position, digInfo.position);
            if (distanceToDigPlace <= maxDigDistance)
            {
                //Do dig here
                Debug.Log("Dig");
                digInfo.Dig();
            }
        }
    }

    private void DigInRange(Vector2 digPlacePosition, Vector3 digPlaceRotation, DigPlace script)
    {
        digInfo.SetDigPlace(digPlacePosition, digPlaceRotation, script);
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
            DigInRange(digPlaceTransform.position, digPlaceTransform.rotation.eulerAngles, collision.GetComponent<DigPlace>());
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
