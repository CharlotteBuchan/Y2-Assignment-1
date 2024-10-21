using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour
{

    public float Speed = 10f;

    private bool isRotating = false;

    private float startMousePosition;

    int UILayer;

    // Start is called before the first frame update
    void Start()
    {
        UILayer = LayerMask.NameToLayer("Rotation Bounds");
    }

    // Update is called once per frame
    // Rotates model if mouse touched in UI element
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & IsPointerOverUIElement())
        {
            isRotating = true;
            startMousePosition = Input.mousePosition.x;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float currentMousePosition = Input.mousePosition.x;
            float mouseMovement = currentMousePosition - startMousePosition;

            transform.Rotate(Vector3.up, -mouseMovement * Speed * Time.deltaTime);
            startMousePosition = currentMousePosition;
        }
    }

    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }

    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }

    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
