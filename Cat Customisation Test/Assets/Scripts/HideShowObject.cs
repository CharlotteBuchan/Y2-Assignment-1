using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowObject : MonoBehaviour
{
    public string modelName;
    [SerializeField] private GameObject model;


    private void Start()
    {
        model = GameObject.Find(modelName);
    }

    public void Hide()
    {
        zAxisHide();
    }

    public void Show()
    {
        zAxisShow();
    }

    public void HideOrShow()
    {
        if (!IsHidden())
        {
            zAxisHide();
        }

        else if (IsHidden())
        {
            zAxisShow();
        }
    }

    private int zSubtract = +100;
    private int zAdd = -50;

    public void zAxisHide()
    {
        Vector3 currentPosition = model.transform.position;
        currentPosition.z = zSubtract; // Set the new Z position
        model.transform.position = currentPosition;
    }

    public void zAxisShow()
    {
        Vector3 currentPosition = model.transform.position;
        currentPosition.z = zAdd; // Set the new Z position
        model.transform.position = currentPosition;
    }

    public bool IsHidden()
    {
        Vector3 currentPosition = model.transform.position;
        if (currentPosition.z > 0.1)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
