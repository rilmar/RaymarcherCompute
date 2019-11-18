using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class CameraCompute : MonoBehaviour
{

    public ComputeShader fractalShader;

    // Initialize any variables here

    // Public variables are editable in Unity from the UI and other code files
    public int publicInteger = 0;

    // Serialized private variables are editable in the UI but not from other code files
    [SerializeField]
    private int serializedPrivateInteger = 0;

    // Private, non-serialized variables cannot be edited in the UI or from other code files
    private int privateInteger = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
