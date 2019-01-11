using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLEGO : MonoBehaviour {

	float rotSpeed = 20;
    Renderer rend;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame
    void OnMouseDrag() {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        Debug.Log(rotX);
        Debug.Log(rotY);

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);
    }
}
