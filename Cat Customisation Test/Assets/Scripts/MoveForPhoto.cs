using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveForPhoto : MonoBehaviour
{
    public string models = "Models";
    [SerializeField] private GameObject _models;

    private int xMiddle = 0;
    private int xCustom = -15;

    private HideShowObject hideShow;


    private void Start()
    {
        _models = GameObject.Find(models);
    }

    public void xAxisMiddle()
    {
        Vector3 currentPosition = _models.transform.position;
        currentPosition.x = xMiddle; // Set the new Z position
        _models.transform.position = currentPosition;

    }

    public void xAxisCustom()
    {
        Vector3 currentPosition = _models.transform.position;
        currentPosition.x = xCustom; // Set the new Z position
        _models.transform.position = currentPosition;
    }
}
