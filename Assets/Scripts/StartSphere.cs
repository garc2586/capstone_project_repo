using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSphere : MonoBehaviour
{
    public GameObject startingImage = null;
    // Start is called before the first frame update
    void Start()
    {
        if (startingImage != null)
            startingImage.GetComponentInChildren<SphereChanger>().ChangePos();
        else
            Debug.LogError("No starting image.");
    }
}
