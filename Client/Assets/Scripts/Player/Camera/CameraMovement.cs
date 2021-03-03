using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CaptureObject;
    public float Speed;
    public Vector3 offset;
    void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, CaptureObject.transform.position + offset, Time.deltaTime * 100);
    }

    // Update is called once per frame
    void Update()
    {
        float m = 5f;
        if ((transform.position.x + m < CaptureObject.transform.position.x + offset.x) || (transform.position.x - m > CaptureObject.transform.position.x + offset.x))
        {
            transform.position = Vector3.MoveTowards(transform.position, CaptureObject.transform.position + offset, Time.deltaTime * Speed);
        }
        if ((transform.position.z + m < CaptureObject.transform.position.z) || (transform.position.z - m > CaptureObject.transform.position.z))
        {
            transform.position = Vector3.MoveTowards(transform.position, CaptureObject.transform.position + offset, Time.deltaTime * Speed);
        }
        if (transform.position.y != (CaptureObject.transform.position.y + offset.y))
        {
            transform.position = Vector3.MoveTowards(transform.position, CaptureObject.transform.position + offset, Time.deltaTime * Speed);
        }

    }


}
