using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMarker : MonoBehaviour
{
     public Camera mainCamera; // Drag the main camera here in the Inspector
    public float distanceFromCamera = 5.0f; // Distance from the camera if nothing is hit
    public LayerMask markerLayer; // Set this to the layer of your prefab object(s)
    public GameObject markerPrefab; // Assign the knife or marker object

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

        // Check if the ray hits any object in the specified marker layer
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, markerLayer))
        {
            // Position the knife/marker at the hit point on the prefab object
            markerPrefab.transform.position = hit.point;

            // Optionally, adjust the rotation to ensure the knife is correctly aligned
            // Align with the normal of the surface where it hit
            markerPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            // Fix the x-axis rotation to 90 degrees (or any specific rotation you want)
            Vector3 knifeEuler = markerPrefab.transform.rotation.eulerAngles;
            markerPrefab.transform.rotation = Quaternion.Euler(90, knifeEuler.y, knifeEuler.z);
        }
        else
        {
            // If the ray doesn't hit the object, position the knife at a default location (in front of the camera)
            Vector3 targetPosition = ray.GetPoint(distanceFromCamera);
            markerPrefab.transform.position = targetPosition;

            // Keep the fixed rotation in front of the camera
            markerPrefab.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}
