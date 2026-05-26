using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Range(0f,10f)] 
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        if(target == null) return;

        // Calculate the desired position based on the target's position and the offset
        Vector3 desiredPosition = target.transform.position + offset;

        // Smoothly interpolate between the current position and the desired position
        transform.position = Vector3.Lerp(
           transform.position,
           desiredPosition,
           smoothSpeed * Time.deltaTime
        );

    }


}
