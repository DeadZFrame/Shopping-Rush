using System.Collections;
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

    //public IEnumerator Shake(float duration,float magnitude)
    //{
    //    float elapsed = 0.0f;

    //    while (elapsed < duration)
    //    {
    //        float x = Random.Range(-0.2f, 0.2f) * magnitude;
    //        float y = Random.Range(-0.2f, 0.2f) * magnitude;

    //        transform.localPosition = new Vector3(x, y);

    //        elapsed += Time.deltaTime;

    //        yield return null;
    //    }
    //}
}
