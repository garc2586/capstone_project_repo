using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLabel : MonoBehaviour
{
    private GameObject main_camera;
    // Start is called before the first frame update
    void Awake()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (main_camera != null)
        {
            transform.LookAt(transform.position + main_camera.transform.rotation * Vector3.forward, main_camera.transform.rotation * Vector3.up);
        }
    }
}
