using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChanger : MonoBehaviour {



    //This object should be called 'Fader' and placed over the camera
    GameObject m_Fader;

    //This ensures that we don't mash to change spheres
    bool changing = false;

    public Transform sphereToTransferTo;
    private GameObject player;

    void Awake()
    {

        //Find the fader object
        m_Fader = GameObject.Find("Fader");

        //Check if we found something
        if (m_Fader == null)
            Debug.LogWarning("No Fader object found on camera.");

        player = GameObject.FindGameObjectWithTag("Player");

    }

    //Here is your old code from OnMouseDown -Theo
    public void ChangePos()
    {

        Vector3 idealPosition = sphereToTransferTo.position;
        idealPosition.y = -1.2f;
        player.transform.position = idealPosition;
    }

    



   

}
