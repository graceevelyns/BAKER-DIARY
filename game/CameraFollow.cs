using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public Vector3 offset;   // Offset position from the target
    public float smoothTime = 0.3f; // Time for the camera to catch up to the target

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Define the target position based on target's position and offset
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
