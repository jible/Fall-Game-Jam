﻿using UnityEngine;

namespace Polyperfect.Universal
{
     public Camera mainCamera; // Drag the main camera here in the Inspector
    public float distanceFromCamera = 5.0f; // How far the knife is from the camera
    public LayerMask raycastLayers; // To control what layers the knife can interact with (optional)

    private void Start()
    {
        // Hide the default system cursor
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position to a ray
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        // Check if the ray hits any object within the specified layers
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayers))
        {
            // If raycast hits something, position the knife at the hit point
            transform.position = hit.point;
        }
        else
        {
            // If nothing is hit, position the knife in front of the camera at a fixed distance
            Vector3 targetPosition = ray.GetPoint(distanceFromCamera);
            transform.position = targetPosition;
        }

        // Optionally, rotate the knife to always face the hit object or move naturally
        transform.rotation = Quaternion.LookRotation(ray.direction);
    }
}
  