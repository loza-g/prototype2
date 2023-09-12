using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this value to control the movement speed.

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the mouse position in world coordinates.

        // Make sure the object stays in the Z-plane and follows the mouse horizontally and vertically.
        mousePosition.z = transform.position.z;

        // Clamp the object's position to stay within the screen boundaries.
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(mousePosition.x, ScreenUtils.ScreenMin.x, ScreenUtils.ScreenMax.x),
            Mathf.Clamp(mousePosition.y, ScreenUtils.ScreenMin.y, ScreenUtils.ScreenMax.y),
            transform.position.z
        );

        // Move the object towards the clamped mouse position.
        transform.position = Vector3.MoveTowards(transform.position, clampedPosition, moveSpeed * Time.deltaTime);
    }


}