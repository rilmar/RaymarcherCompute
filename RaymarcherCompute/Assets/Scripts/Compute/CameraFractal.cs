using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFractal : CameraCompute
{
    [Range(1, 12)]
    public float power = 2.0f;
    [Range(1f, 10f)]
    public float epsilon = 0.001f;
    [Range(50, 500)]
    public float maxDistance = 200.0f;
    [Range(50, 500)]
    public int maxSteps = 500;
    [Range(0, 1)]
    public float rimLight = 0.5f;

    public float powerStep = 0.2f;

    private float powerMax = 12.0f;
    private float powerMin = 1.0f;

    public KeyCode powerDecreaseKey;
    public KeyCode powerIncreaseKey;

    private Light sceneLight;

    public override void GetSceneInformation()
    {
        base.GetSceneInformation();
        sceneLight = FindObjectOfType<Light>();
    }

    public override void SetShaderUserParameters(RenderTexture source)
    {
        base.SetShaderUserParameters(source);
        UserShader.SetTexture(0, "_ImageInput", source); // this is the surrounding unity scene

        UserShader.SetFloat("_Power", power);
        UserShader.SetFloat("_Epsilon", (epsilon / 5000.0f));
        UserShader.SetFloat("_MaxDistance", maxDistance);
        UserShader.SetFloat("_MaxSteps", maxSteps);
        UserShader.SetFloat("_Rim", rimLight);

        UserShader.SetVector("_LightDirection", sceneLight.transform.forward);

    }

    private void Update()
    {
        if (Input.GetKey(powerIncreaseKey))
        {
            power += powerStep;
            power = Mathf.Clamp(power, powerMin, powerMax);


        }
        else if (Input.GetKey(powerDecreaseKey))
        {
            power -= powerStep;
            power = Mathf.Clamp(power, powerMin, powerMax);
        }

    }

}
