using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInput : MonoBehaviour
{
    public bool left;
    TransformModel trans;

    public void Start()
    {
        trans = GameObject.FindGameObjectWithTag("Input").GetComponent<TransformModel>();
    }

    public void ProcessInput()
    {
        if(left)
            trans.LeftMove();
        else
            trans.RightMove();
    }
}
