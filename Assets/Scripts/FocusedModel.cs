using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusedModel : MonoBehaviour
{
    public GameObject model;
    public GameObject inputModels;
    GameObject player;


    public void Start()
    {
        model = null;
        player = GameObject.FindGameObjectWithTag("PlayerLoc");
    }
    public void SetModel(GameObject modelIn)
    {
        model = modelIn;
    }

    public void updateInput(Operation state)
    {
        if (state == Operation.NONE)
        {
            inputModels.SetActive(false);
        }
        else
        {
            if (state == Operation.ROTATE)
            {
                inputModels.SetActive(true);
                inputModels.transform.position = player.transform.position + (player.transform.forward * 0.5f);
                inputModels.transform.LookAt(player.transform.position);
                //inputModels.transform.Translate(Vector3.up * 1.2f);
                //inputModels.transform.RotateAround(player.transform.position,Vector3.up,player.transform.rotation.eulerAngles.x + 90.0f);
            }
            inputModels.GetComponent<SetGuide>().GuideState(state);
            switch (state)
            {
                case Operation.ROTATE:
                    inputModels.GetComponent<InputLabels>().setLeftLabel("Left");
                    inputModels.GetComponent<InputLabels>().setRightLabel("Right");
                    break;
                case Operation.SCALE:
                    inputModels.GetComponent<InputLabels>().setLeftLabel("Smaller");
                    inputModels.GetComponent<InputLabels>().setRightLabel("Larger");
                    break;
                case Operation.XMOV:
                    inputModels.GetComponent<InputLabels>().setLeftLabel("Move Left");
                    inputModels.GetComponent<InputLabels>().setRightLabel("Move Right");
                    break;
                case Operation.YMOV:
                    inputModels.GetComponent<InputLabels>().setLeftLabel("Move Left");
                    inputModels.GetComponent<InputLabels>().setRightLabel("Move Right");
                    break;
                case Operation.ZMOV:
                    inputModels.GetComponent<InputLabels>().setLeftLabel("Move Left");
                    inputModels.GetComponent<InputLabels>().setRightLabel("Move Right");
                    break;
            }
        }
    }
}
