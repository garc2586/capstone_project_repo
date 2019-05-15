using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderQueue : MonoBehaviour
{
    public int render = 3000;
    public Material mat;

    void Start()
    {
        CanvasRenderer rend = gameObject.GetComponent<CanvasRenderer>();
        if(rend == null)
        {
            Debug.LogError("Attempting to change render queue of object without canvas renderer " + gameObject.name);
            return;
        }
        if(mat == null)
        {
            Debug.LogError("Attempting to change render queue of object without materail " + gameObject.name);
            return;
        }
        rend.SetMaterial(mat,1);
        rend.GetMaterial().renderQueue = render;
    }

}
