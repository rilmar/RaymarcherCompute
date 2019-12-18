using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public KeyCode screenshotKey = KeyCode.Space;
    private int index = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            for(int i = index; i < 1000; i++)
            {
                if (!System.IO.File.Exists("raymarch" + i + ".png"))
                {
                    ScreenCapture.CaptureScreenshot("raymarch" + i + ".png", 4);
                    Debug.Log("Screenshot taken: raymarch" + i + ".png");
                    index = i;
                    break;
                }
            }
        }
    }
}
