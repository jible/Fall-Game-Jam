using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehavior : MonoBehaviour
{
    // Array to hold references to the Canvases
    public Canvas[] canvases;

    // This method will be called when the button is clicked
    public void ToggleCanvasVisibility()
    {
        // Loop through each canvas and toggle its visibility
        foreach (Canvas canvas in canvases)
        {
            // Set the canvas to active/inactive
            canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        }
    }

}
