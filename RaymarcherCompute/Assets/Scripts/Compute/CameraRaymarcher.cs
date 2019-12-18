using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaymarcher : CameraCompute
{

    private Light sceneLight;

    [Range(0, 3)]
    public int SceneMode;

    public Transform objectAPosition;
    public Transform objectBPosition;

    public float surfaceThreshold = 0.0005f;

    [Range(0,1)]
    public float colorModifier;

    public float AScale;
    public float BScale;
    public KeyCode AScaleUp;
    public KeyCode AScaleDown;
    public KeyCode BScaleUp;
    public KeyCode BScaleDown;

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

        float[] fa = { objectAPosition.position.x, objectAPosition.position.y, objectAPosition.position.z };
        UserShader.SetFloats("_APosition", fa);

        float[] fb = { objectBPosition.position.x, objectBPosition.position.y, objectBPosition.position.z };
        UserShader.SetFloats("_BPosition", fb);

        float[] sa = { AScale, AScale, AScale };
        UserShader.SetFloats("_AScale", sa);

        float[] sb = { BScale, BScale, BScale };
        UserShader.SetFloats("_BScale", sb);

        //UserShader.SetVector("_LightDirection", sceneLight.transform.forward);

    }

    private void Update()
    {
        if (Input.GetKey(AScaleUp))
        {
            AScale += ScaleStep;
            AScale = Mathf.Clamp(AScale, MinScale, MaxScale);


        }
        else if (Input.GetKey(AScaleDown))
        {
            AScale -= ScaleStep;
            AScale = Mathf.Clamp(AScale, MinScale, MaxScale);
        }

        if (Input.GetKey(BScaleUp))
        {
            BScale += ScaleStep;
            BScale = Mathf.Clamp(BScale, MinScale, MaxScale);


        }
        else if (Input.GetKey(BScaleDown))
        {
            BScale -= ScaleStep;
            BScale = Mathf.Clamp(BScale, MinScale, MaxScale);
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
