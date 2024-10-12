using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMarker : MonoBehaviour
{
    public Camera mainCamera; // Assign the main camera
    public LayerMask drawableLayer; // Layer of the object you want to draw on
    public GameObject markerPrefab; // Knife or marker object
    public Material lineMaterial; // Material to use for the drawn lines

    private List<Vector3> points = new List<Vector3>(); // Stores points where the knife draws
    private LineRenderer currentLineRenderer; // The line renderer to draw the lines
    private bool isDrawing = false; // Is the knife currently drawing?

    private void Update()
    {
        // Get the mouse position and convert it into a ray
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits the object in the drawable layer
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, drawableLayer))
        {
            // Position the marker (knife) at the hit point on the object's surface
            markerPrefab.transform.position = hit.point;

            // Lock the X-axis rotation to 90 degrees for the marker
            Vector3 normal = hit.normal;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, normal);
            markerPrefab.transform.rotation = Quaternion.Euler(90, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

            // Check if the mouse button is pressed to start drawing
            if (Input.GetMouseButtonDown(0))
            {
                StartDrawing(hit.point);
            }

            // If the mouse button is held down, continue drawing
            if (Input.GetMouseButton(0) && isDrawing)
            {
                AddPointToLine(hit.point);
            }

            // If the mouse button is released, stop drawing
            if (Input.GetMouseButtonUp(0))
            {
                StopDrawing();
            }
        }
    }

    // Start drawing: Initialize a new line renderer when the user clicks
    private void StartDrawing(Vector3 startPoint)
    {
        isDrawing = true;

        // Create a new GameObject to hold the line renderer
        GameObject lineObj = new GameObject("DrawnLine");
        currentLineRenderer = lineObj.AddComponent<LineRenderer>();

        // Configure the line renderer
        currentLineRenderer.material = lineMaterial;
        currentLineRenderer.startWidth = 0.02f; // Adjust the width as needed
        currentLineRenderer.endWidth = 0.02f;   // Adjust the width as needed
        currentLineRenderer.positionCount = 0;  // No points initially

        // Add the first point
        AddPointToLine(startPoint);
    }

    // Add a point to the current line
    private void AddPointToLine(Vector3 newPoint)
    {
        points.Add(newPoint);
        currentLineRenderer.positionCount = points.Count;
        currentLineRenderer.SetPosition(points.Count - 1, newPoint);
    }

    // Stop drawing: Reset the state when the user releases the mouse button
    private void StopDrawing()
    {
        isDrawing = false;
        points.Clear(); // Clear points for the next line
    }
}
