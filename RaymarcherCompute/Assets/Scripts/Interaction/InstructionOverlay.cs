using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionOverlay : MonoBehaviour
{
    [Tooltip("UI to display on key press")]
    public CanvasGroup HelpPanel;

    public KeyCode helpKey = KeyCode.H;


    void Update()
    {
        if (Input.GetKey(helpKey))
        {

            Show(HelpPanel);

        } else
        {
            Hide(HelpPanel);
        }

    }

    void Hide(CanvasGroup cg)
    {
        cg.alpha = 0f;
        cg.blocksRaycasts = false;
    }

    void Show(CanvasGroup cg)
    {
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
    }
}
