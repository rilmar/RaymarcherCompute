using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaymarcher : CameraCompute
{

    private Light sceneLight;

    [Range(0, 3)]
    public int SceneMode;

    public Transform objectPosition;

    public float surfaceThreshold = 0.0005f;

    [Range(0,1)]
    public float colorModifier;

    public float Scale;
    public KeyCode ScaleUp;
    public KeyCode ScaleDown;

    public float MinScale = 0.5f;
    public float MaxScale = 2.0f;
    public float ScaleStep = 0.1f;


    public override void GetSceneInformation()
    {
        base.GetSceneInformation();
        sceneLight = FindObjectOfType<Light>();
    }

    public override void SetShaderUserParameters(RenderTexture source)
    {
        base.SetShaderUserParameters(source);
        // UserShader.SetTexture(0, "_ImageInput", source); // this is the surrounding unity scene

        UserShader.SetInt("_SceneMode", SceneMode);
        UserShader.SetFloat("_SurfaceThreshold", surfaceThreshold);

        UserShader.SetFloat("_ColorModifier", colorModifier);
        float[] f = { objectPosition.position.x, objectPosition.position.y, objectPosition.position.z };
        UserShader.SetFloats("_Position", f);
        float[] s = { Scale, Scale, Scale };
        UserShader.SetFloats("_Scale", s);

        //UserShader.SetVector("_LightDirection", sceneLight.transform.forward);

    }

    private void Update()
    {
        if (Input.GetKey(ScaleUp))
        {
            Scale += ScaleStep;
            Scale = Mathf.Clamp(Scale, MinScale, MaxScale);


        }
        else if (Input.GetKey(ScaleDown))
        {
            Scale -= ScaleStep;
            Scale = Mathf.Clamp(Scale, MinScale, MaxScale);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneMode = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneMode = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneMode = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneMode = 3;
        }
    }
}
