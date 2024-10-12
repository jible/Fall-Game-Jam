using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMove : MonoBehaviour
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

        // Lock rotation to 90 degrees on the X-axis while allowing other axes to rotate naturally
        Quaternion knifeRotation = Quaternion.LookRotation(ray.direction);
        knifeRotation = Quaternion.Euler(90, knifeRotation.eulerAngles.y, knifeRotation.eulerAngles.z);
        transform.rotation = knifeRotation;
    }
}
