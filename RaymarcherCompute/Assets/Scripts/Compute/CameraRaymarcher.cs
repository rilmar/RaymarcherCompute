using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaymarcher : CameraCompute
{

    private Light sceneLight;


    public override void GetSceneInformation()
    {
        base.GetSceneInformation();
        sceneLight = FindObjectOfType<Light>();
    }

    public override void SetShaderUserParameters(RenderTexture source)
    {
        base.SetShaderUserParameters(source);
        // UserShader.SetTexture(0, "_ImageInput", source); // this is the surrounding unity scene

        //UserShader.SetFloat("_Power", power);
        //UserShader.SetFloat("_Epsilon", (epsilon / 5000.0f));
        //UserShader.SetFloat("_MaxDistance", maxDistance);
        //UserShader.SetFloat("_MaxSteps", maxSteps);
        //UserShader.SetFloat("_Rim", rimLight);

        //UserShader.SetVector("_LightDirection", sceneLight.transform.forward);

    }

    private void Update()
    {
    //    if (Input.GetKey(powerIncreaseKey))
    //    {
    //        power += powerStep;
    //        power = Mathf.Clamp(power, powerMin, powerMax);


    //    }
    //    else if (Input.GetKey(powerDecreaseKey))
    //    {
    //        power -= powerStep;
    //        power = Mathf.Clamp(power, powerMin, powerMax);
    //    }

    }
}
