using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    // Use this for initialization
    public Transform Rotationpoint;
    public float RotSpeed = 20;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //right
            Rotationpoint.transform.Rotate(new Vector3(0, -RotSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //left
            Rotationpoint.transform.Rotate(new Vector3(0, RotSpeed * Time.deltaTime, 0));
        }

    }



}