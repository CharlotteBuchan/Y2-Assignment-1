using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
    public SkinnedMeshRenderer skinMeshRenderer;
    [SerializeField] string model;
    [SerializeField] Material material;

    public ColourPickerControl colourPickerControl;

    public Color newColour;

    // Start is called before the first frame update
    void Start()
    {
        skinMeshRenderer = GameObject.Find(model).GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaterial()
    {
        newColour = colourPickerControl.GetColor();
        skinMeshRenderer.material = material;
        skinMeshRenderer.material.SetColor("_Color", newColour);
    }
}
