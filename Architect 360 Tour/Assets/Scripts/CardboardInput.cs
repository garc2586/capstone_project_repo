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
            Debug.Log(hit.transform.parent.tag);
            hit.transform.GetComponent<SphereChanger>().ChangePos();
        }
    }
}
