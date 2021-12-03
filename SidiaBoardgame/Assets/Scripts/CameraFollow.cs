using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 cameraDisplacement;

    public float smooth = 1f;

    private void Start()
    {
        cameraDisplacement = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = target.position + cameraDisplacement;
        transform.position = Vector3.Slerp(transform.position, cameraPosition, smooth * Time.deltaTime);
    }
}
