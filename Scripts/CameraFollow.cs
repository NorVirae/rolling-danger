using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraTarget;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - cameraTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPosition = Vector3.SmoothDamp(transform.position, cameraTarget.position + offset, ref velocity, smoothTime);
        //transform.position = targetPosition;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, cameraTarget.position + offset, ref velocity, smoothTime);
        transform.position = targetPosition;
    }

  
}
