using UnityEngine;
 
public class CameraFollow : MonoBehaviour
{
    public Transform cart;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 cameraPosition = cart.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
