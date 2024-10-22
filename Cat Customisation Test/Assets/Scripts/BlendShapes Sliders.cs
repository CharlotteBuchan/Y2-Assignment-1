using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlendShapesSliders : MonoBehaviour
{
    private SkinnedMeshRenderer skinMeshRenderer;
    [SerializeField] Slider _shapeSlider;
    [SerializeField] float value;
    [SerializeField] string model;
    [SerializeField] int shapeKey;

    // get SkinnedMeshRenderer from picked model, to get blend shape key
    void Start()
    {
        skinMeshRenderer = GameObject.Find(model).GetComponent<SkinnedMeshRenderer>();
        _shapeSlider.value = skinMeshRenderer.GetBlendShapeWeight(shapeKey);
    }

    void Update()
    {
        value = _shapeSlider.value;
    }

    // Update is called once per frame
    public void ChangeShape()
    {
        value = _shapeSlider.value;
        skinMeshRenderer.SetBlendShapeWeight(shapeKey, value);
    }
}
