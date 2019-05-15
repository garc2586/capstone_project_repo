using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardInput : MonoBehaviour
{
    RaycastHit hitLeft, hitRight;
    public GameObject cameraLeft, cameraRight;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 10);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(cameraLeft.transform.position, cameraLeft.transform.forward, out hitRight) && Physics.Raycast(cameraRight.transform.position, cameraRight.transform.forward, out hitRight))
        {
            Debug.Log("Ray");
            Debug.Log(hitLeft.transform.tag);
            Component input = hitLeft.transform.GetComponent<SphereChanger>();
            if (input != null)
                hitLeft.transform.GetComponent<SphereChanger>().ChangePos();
            else {
                input = hitLeft.transform.GetComponent<EditModel>();
                if (input != null)
                    hitLeft.transform.GetComponent<EditModel>().ProcessInput();
                else
                    Debug.Log("Object " + hitLeft.transform.name + " doesn't manage input");
            }
        }
    }
}
