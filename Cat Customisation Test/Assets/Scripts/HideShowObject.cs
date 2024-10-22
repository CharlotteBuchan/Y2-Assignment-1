using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowObject : MonoBehaviour
{
    public string modelName;
    [SerializeField] private GameObject model;

    private void Start()
    {
        GameObject model = GameObject.Find(modelName);
    }

    public void Hide()
    {
        model.SetActive(false);
    }

    public void Show()
    {
        model.SetActive(true);
    }

    public void HideOrShow()
    {
        if(model.activeSelf)
        {
            model.SetActive(false);
        }

        else if(!model.activeSelf)
        {
            model.SetActive(true);
        }
    }
}
