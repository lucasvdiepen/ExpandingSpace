using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerMouse : MonoBehaviour
{
    //For clicking buttons with controller
    //https://stackoverflow.com/questions/46198428/generate-clickmousebutton0-anywhere-on-display

    public float mouseSpeed = 5f;

    public GraphicRaycaster[] graphicRaycasters;

    private bool controllerMouseIsEnabled = false;

    PlayerControls playerControls;

    Vector2 controllerStick = Vector2.zero;

    Vector2 previousMousePosition = Vector2.zero;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.UI.ControllerMouse.performed += ctx => controllerStick = ctx.ReadValue<Vector2>();
        playerControls.UI.ControllerClick.performed += ctx => SimulateMouseButtonClick();
        playerControls.UI.ControllerMouse.canceled += ctx => controllerStick = Vector2.zero;
    }

    private void OnEnable()
    {
        playerControls.UI.Enable();
    }

    private void OnDisable()
    {
        playerControls.UI.Disable();
    }

    public void SetControllerMouse(bool enable)
    {
        controllerMouseIsEnabled = enable;
        previousMousePosition = new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue());
    }

    private void SimulateMouseButtonClick()
    {
        if(controllerMouseIsEnabled)
        {
            Debug.Log("Simulate click");

            /*Vector3 worldPoint = Camera.main.ScreenToWorldPoint(previousMousePosition);
            worldPoint.z = Camera.main.transform.position.z;
            Ray ray = new Ray(worldPoint, new Vector3(0, 0, 1));
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, new Vector3(0, 0, 1));
            if(hit.collider != null)
            {
                Debug.Log("Hit with collider");

                if (hit.transform.tag == "UIButton")
                {
                    Debug.Log("Hit UI button");
                    Button hitButton = hit.transform.gameObject.GetComponent<Button>();
                    ExecuteEvents.Execute(hitButton.gameObject, new BaseEventData(GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>()), ExecuteEvents.submitHandler);
                }
            }*/

            PointerEventData pointerEventData = new PointerEventData(GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>());
            pointerEventData.position = previousMousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            foreach(GraphicRaycaster raycaster in graphicRaycasters)
            {
                raycaster.Raycast(pointerEventData, results);
            }

            foreach(RaycastResult result in results)
            {
                if(result.gameObject.tag == "UIButton")
                {
                    Debug.Log("Button click");
                    ExecuteEvents.Execute(result.gameObject, new BaseEventData(GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>()), ExecuteEvents.submitHandler);
                }
            }
        }
    }

    void Update()
    {
        if (controllerMouseIsEnabled && controllerStick != Vector2.zero)
        {
            Vector2 newMousePosition = previousMousePosition + (controllerStick * mouseSpeed * Time.unscaledDeltaTime);
            Debug.Log(newMousePosition);
            Mouse.current.WarpCursorPosition(newMousePosition);
            previousMousePosition = newMousePosition;
        }
    }
}
