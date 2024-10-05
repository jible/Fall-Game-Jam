using UnityEngine;

public class MoveObjectWithMouse : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    private float mZCoord;
    private bool isDragging = false;

    // Speed factor for dragging
    public float dragSpeed = 5f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        // offset = transform.position - GetMouseWorldPosition();
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        Vector3 newPosition = GetMouseWorldPosition() + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, dragSpeed * Time.deltaTime);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = mZCoord; // Distance from camera
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}