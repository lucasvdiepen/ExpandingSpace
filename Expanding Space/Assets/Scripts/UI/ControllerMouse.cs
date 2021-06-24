using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerMouse : MonoBehaviour
{
    public float mouseSpeed = 1000f;

    private GraphicRaycaster graphicsRaycaster;

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

    private void Start()
    {
        graphicsRaycaster = GetComponent<GraphicRaycaster>();
    }

    private void OnEnable()
    {
        playerControls.UI.Enable();
    }

    private void OnDisable()
    {
        playerControls.UI.Disable();
    }

    private void SimulateMouseButtonClick()
    {
        Debug.Log("Simulate click");

        PointerEventData pointerEventData = new PointerEventData(GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>());
        pointerEventData.position = previousMousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        graphicsRaycaster.Raycast(pointerEventData, results);

        foreach(RaycastResult result in results)
        {
            if(result.gameObject.tag == "UIButton")
            {
                ExecuteEvents.Execute(result.gameObject, new BaseEventData(GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>()), ExecuteEvents.submitHandler);
            }
        }
    }

    void Update()
    {
        if (controllerStick != Vector2.zero)
        {
            Vector2 newMousePosition = previousMousePosition + (controllerStick * mouseSpeed * Time.unscaledDeltaTime);
            Debug.Log(newMousePosition);
            Mouse.current.WarpCursorPosition(newMousePosition);
            previousMousePosition = newMousePosition;
        }
    }
}
