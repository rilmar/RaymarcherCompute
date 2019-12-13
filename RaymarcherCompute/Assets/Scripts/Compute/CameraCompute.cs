using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script used to setup base functionality of attching compute shader to camera
 * Extend script to implement more complicated shaders
 * This script will run compute shader with only a few base inputs, including:
 *
 * camera position
 * camera projection
 * result texture for return
 *
 * Credit to http://blog.three-eyed-games.com/2018/05/03/gpu-ray-tracing-in-unity-part-1/
 * for initial instruction
 */


[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class CameraCompute : MonoBehaviour
{
    public ComputeShader UserShader;
    private RenderTexture _target;
    private Camera _camera;

    public virtual void GetSceneInformation()
    {

    }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void SetShaderCameraParameters()
    {
        UserShader.SetMatrix("_CameraToWorld", _camera.cameraToWorldMatrix);
        UserShader.SetMatrix("_CameraInverseProjection", _camera.projectionMatrix.inverse);
    }

    public virtual void SetShaderUserParameters(RenderTexture source)
    {

    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        GetSceneInformation();
        SetShaderCameraParameters();
        SetShaderUserParameters(source);
        Render(destination);
    }

    private void Render(RenderTexture destination)
    {
        // Make sure we have a current render target
        InitRenderTexture();

        // Set the target and dispatch the compute shader
        UserShader.SetTexture(0, "Result", _target);
        UserShader.SetInt("ResultWidth", _target.width);
        UserShader.SetInt("ResultHeight", _target.height);
        // Create thread groups
        int threadGroupsX = Mathf.CeilToInt(Screen.width / 8.0f);
        int threadGroupsY = Mathf.CeilToInt(Screen.height / 8.0f);
        UserShader.Dispatch(0, threadGroupsX, threadGroupsY, 1);

        // Blit the result texture to the screen
        Graphics.Blit(_target, destination);
    }

    private void InitRenderTexture()
    {
        if (_target == null || _target.width != Screen.width || _target.height != Screen.height)
        {
            // Release render texture if we already have one
            if (_target != null)
                _target.Release();
            // Get a render target for Ray Tracing
            _target = new RenderTexture(Screen.width, Screen.height, 0,
                RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
            _target.enableRandomWrite = true;
            _target.Create();
        }
    }

}
