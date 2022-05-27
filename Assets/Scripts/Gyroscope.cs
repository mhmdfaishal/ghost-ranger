// Create a cube with camera vector names on the faces.
// Allow the device to show named faces as it is oriented.
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gyroscope : MonoBehaviour
{


    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.Log("Gyroscope not supported");
        }
    }


    protected void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            GyroModifyCamera();
        }
    }


    /********************************************/

    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroModifyCamera()
    {
        transform.rotation = GyroToUnity(Input.gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}