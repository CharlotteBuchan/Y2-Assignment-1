using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MeshSVImageControls : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Image pickerImage;

    private RawImage SVimage;

    private MeshColourPickerControl CC;

    public GameObject pickerHolder;

    private RectTransform rectTransform, pickerTransform;

    // Calculate the boundaries based on the rect size

    float halfWidth;
    float halfHeight;

    private void Awake()
    {
        SVimage = GetComponent<RawImage>();
        CC = FindObjectOfType<MeshColourPickerControl>();
        rectTransform = GetComponent<RectTransform>();

        

        pickerTransform = pickerImage.GetComponent<RectTransform>();
        //pickerTransform.position = new Vector2(pickerHolder.transform.position.x, pickerHolder.transform.position.y);

       
        // Calculate half width and half height
        halfWidth = pickerTransform.rect.width * 1.5f;
        halfHeight = pickerTransform.rect.height * 1.5f;

        // Set the pickerTransform to the top-left position of the pickerHolder
        Vector2 topLeftPosition = pickerTransform.position + new Vector3(-halfWidth, halfHeight, 0);
        pickerTransform.position = topLeftPosition;

    }

    void UpdateColour(PointerEventData eventData)
    {
        // Convert the event position to the local coordinate system of the picker
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPoint);

        halfWidth = pickerHolder.GetComponent<RectTransform>().rect.width * 0.5f;
        halfHeight = pickerHolder.GetComponent<RectTransform>().rect.height * 0.5f;

        // Clamp the position
        localPoint.x = Mathf.Clamp(localPoint.x, -halfWidth, halfWidth);
        localPoint.y = Mathf.Clamp(localPoint.y, -halfHeight, halfHeight);

        // Set the picker position and color
        pickerTransform.localPosition = localPoint;

        // Normalize the position for SV
        float xNorm = (localPoint.x + halfWidth) / (2 * halfWidth);
        float yNorm = (localPoint.y + halfHeight) / (2 * halfHeight);

        // Update the color based on the vertical position
        pickerImage.color = Color.HSVToRGB(0, 0, 1 - yNorm);

        // Pass normalized values to ColourPickerControl
        CC.SetSV(xNorm, yNorm);


    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateColour(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateColour(eventData);
    }

}
