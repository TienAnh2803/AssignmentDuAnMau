using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform target;    // Reference to the player's transform
    public float smoothSpeed = 0.125f; // The speed at which the camera will smooth
    public Vector3 offset;      // The desired offset between the camera and the player

    void FixedUpdate()
    {
        // Desired position of the camera
        Vector3 desiredPosition = target.position + offset;

        // Smooth the movement between current position and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;
    }
}
