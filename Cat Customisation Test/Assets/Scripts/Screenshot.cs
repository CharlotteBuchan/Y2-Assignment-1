using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("silly photoz" + System.DateTime.Now.ToString("dd-MM-yy (HH-mm-ss)") + ".png");
    }

}
