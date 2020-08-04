using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Smoothly follow player.
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPotition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothPotition;

        // Look at player.
        transform.LookAt(target);
    }
}
