using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
    public float smoothSpeed = 0.8f;
    void Update()
    {
        // creates a maximum edgeposition for camera to move in, containing it within game area
        transform.position = new Vector3(
            Mathf.Clamp(followTarget.position.x, -0.59f, 188.90f),
            Mathf.Clamp(followTarget.position.y, -0.31f, -0.25f),
            transform.position.z);
        
    }
    private void LateUpdate()
    {
        // linearly interpolates camera movement to soften it
        Vector3 desiredPosition = transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

