using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowObject : MonoBehaviour
{
    public string modelName;
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject UI;


    private void Start()
    {
        model = GameObject.Find(modelName);
    }

    public void Hide()
    {
        if (model != null)
        {
            zAxisHide();
        }

        else
        {
            UI.SetActive(false);
        }
    }

    public void Show()
    {
        if (model != null)
        {
            zAxisShow();
        }

        else
        {
            UI.SetActive(true);
        }
    }

    public void HideOrShow()
    {
        if (model != null)
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

        else
        {
            if (UI.activeSelf == false)
            {
                UI.SetActive(true);
            }

            else 
            {
                UI.SetActive(false);
            }
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
