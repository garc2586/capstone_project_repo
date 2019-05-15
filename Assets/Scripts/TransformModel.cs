using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformModel : MonoBehaviour
{
    public FocusedModel focus;

    public void Start()
    {
        focus = GameObject.FindGameObjectWithTag("Player").GetComponent<FocusedModel>();
    }

    public void LeftMove()
    {
        if (focus.model != null)
            focus.model.GetComponent<EditModel>().Input(true);
    }

    public void RightMove()
    {
        if (focus.model != null)
            focus.model.GetComponent<EditModel>().Input(false);
    }
}
