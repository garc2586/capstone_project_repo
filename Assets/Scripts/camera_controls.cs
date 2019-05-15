using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controls : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject camera;
    int xMov, yMov;
    // Update is called once per frame
    void Update()
    {
        Input.gyro.enabled = true;
        xMov = 0;
        yMov = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
            xMov -= 20;
        if (Input.GetKey(KeyCode.RightArrow))
            xMov += 20;
        xMov = Mathf.Max(Mathf.Min(xMov, 20), -20); //limit xMov to -20 to 20

        if (Input.GetKey(KeyCode.UpArrow))
            yMov -= 20;
        if (Input.GetKey(KeyCode.DownArrow))
            yMov += 20;
        yMov = Mathf.Max(Mathf.Min(yMov, 20), -20);

        camera.transform.Rotate(Vector3.up * speed * xMov * Time.deltaTime, Space.World);
       
        camera.transform.Rotate(Vector3.right * speed * yMov * Time.deltaTime);
        camera.transform.Rotate(Vector3.zero * speed * Time.deltaTime);

        camera.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, -Input.gyro.rotationRateUnbiased.z);


    }

}
