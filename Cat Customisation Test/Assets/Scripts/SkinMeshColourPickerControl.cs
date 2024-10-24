using UnityEngine.UI;
using UnityEngine;
using TMPro;
//using System.Drawing;

public class ColourPickerControl : MonoBehaviour
{

    public float currentHue, currentsat, currentVal;

    [SerializeField]
    private RawImage hueImage, satValImage, outputImage;

    [SerializeField]
    private Slider hueSlider;

    [SerializeField]
    private TMP_InputField hexInputField;

    private Texture2D hueTexture, svTexture, outputTexture;

    [SerializeField]
    private string model;

    public SkinnedMeshRenderer skinMeshRenderer;

    public Color currentColour;

    private void Start()
    {
        skinMeshRenderer = GameObject.Find(model).GetComponent<SkinnedMeshRenderer>();

        CreateHueImage();

        CreateSVImage();

        CreateOutputImage();

        currentHue = 0;
        currentsat = 0;
        currentVal = 1;

        UpdateOutputImage();
    }

    private void CreateHueImage()
    {
        hueTexture = new Texture2D(1, 16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "HueTexture";

        for (int i = 0; i < hueTexture.height; i++)
        {
            hueTexture.SetPixel(0, i, Color.HSVToRGB((float)i / hueTexture.height, 1, 1f));

        }

        hueTexture.Apply();
        currentHue = 0;

        hueImage.texture = hueTexture;
    }

    private void CreateSVImage()
    {
        svTexture = new Texture2D(16, 16);
        svTexture.wrapMode = TextureWrapMode.Clamp;
        svTexture.name = "SatValTexture";

        for (int y = 0; y < svTexture.height; y++)
        {
            for (int x = 0; x < svTexture.width; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(currentHue, (float)x / svTexture.width, (float)y / svTexture.height));

            }
        }

        svTexture.Apply();
        currentsat = 0;
        currentVal = 0;

        satValImage.texture = svTexture;

    }

    private void CreateOutputImage()
    {
        outputTexture = new Texture2D(1, 16);
        outputTexture.wrapMode = TextureWrapMode.Clamp;
        outputTexture.name = "OutputTexture";

        Color currentColour = Color.HSVToRGB(currentHue, currentsat, currentVal);

        for (int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, currentColour);
        }

        outputTexture.Apply();

        outputImage.texture = outputTexture;

    }

    public Color GetColor()
    {
        currentColour = Color.HSVToRGB(currentHue, currentsat, currentVal);
        return currentColour;
    }

    private void UpdateOutputImage()
    {
        Color currentColour = Color.HSVToRGB(currentHue, currentsat, currentVal);

        for (int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, currentColour);
        }

        outputTexture.Apply();

        hexInputField.text = ColorUtility.ToHtmlStringRGB(currentColour);

        skinMeshRenderer.material.SetColor("_Color", currentColour);

        GetColor();
    }

    public void SetSV(float S, float V)
    {
        currentsat = S;
        currentVal = V;

        UpdateOutputImage();
    }

    public void UpdateSVImage()
    {
        currentHue = hueSlider.value;

        for (int y = 0; y < svTexture.height; y++)
        {
            for (int x = 0; x < svTexture.width; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(currentHue, (float)x / svTexture.width, (float)y / svTexture.height));
            }
        }

        svTexture.Apply();

        UpdateOutputImage();

    }

    public void OnTextInput()
    {
        if(hexInputField.text.Length < 6) { return; }

        Color newCol;

        if (ColorUtility.TryParseHtmlString("#" + hexInputField.text, out newCol))
            Color.RGBToHSV(newCol, out currentHue, out currentsat, out currentVal);

        hueSlider.value = currentHue;

        hexInputField.text = "";

        UpdateOutputImage();
    }
}
