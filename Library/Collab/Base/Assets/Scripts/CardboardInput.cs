using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardInput : MonoBehaviour
{
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 10);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {
            Debug.Log("Ray");
            Debug.Log(hit.transform.tag);
            Component input = hit.transform.GetComponent<SphereChanger>();
            if (input != null)
                hit.transform.GetComponent<SphereChanger>().ChangePos();
            else {
                input = hit.transform.GetComponent<EditModel>();
                if (input != null)
                    hit.transform.GetComponent<EditModel>().ProcessInput();
                else
                    Debug.Log("Object " + hit.transform.name + " doesn't manage input");
            }
        }
    }
}
