using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public KeyCode backKey = KeyCode.Escape;
    public bool enableBackKey = true;

    public bool quitApplication;

    private void Update()
    {
        if (Input.GetKeyDown(backKey))
        {
            if (quitApplication)
            {
                Application.Quit(); // quit app
            }
            else
            {
                LoadScene(0); // 0 is the index of the start scene in build settings
            }
        }
    }

    public void LoadScene(int sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }
}
