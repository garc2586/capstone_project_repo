using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Operation {NONE, ROTATE, SCALE, XMOV, YMOV, ZMOV};
public class EditModel : MonoBehaviour
{
    float rotSpeed = 30.0f, scaleSpeed = 1.01f, transSpeed = .9f;
    Operation state;
    public static FocusedModel focus;
    bool inputPressed = false;

    public void Start()
    {
        state = Operation.NONE;
        focus = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<FocusedModel>();
    }

    public void Input(bool left)
    {
        switch (state)
        {
            case Operation.NONE:
                break;
            case Operation.ROTATE:
                focus.model.transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * (left ? -1 : 1), Space.World);
                break;
            case Operation.SCALE:
                float scale;
                if (left)
                    scale = 1.0f / scaleSpeed;
                else
                    scale = scaleSpeed;

                focus.model.transform.localScale = new Vector3(focus.model.transform.localScale.x * scale, focus.model.transform.localScale.y * scale, focus.model.transform.localScale.z * scale);
                break;
            case Operation.XMOV:
                focus.model.transform.Translate(new Vector3(transSpeed * (left?-1:1) * Time.deltaTime,0,0), Space.World);
                break;
            case Operation.YMOV:
                focus.model.transform.Translate(new Vector3(0, transSpeed * (left ? -1 : 1) * Time.deltaTime, 0), Space.World);
                break;

            case Operation.ZMOV:
                focus.model.transform.Translate(new Vector3(0,0,transSpeed * (left ? -1 : 1) * Time.deltaTime), Space.World);
                break;
        }
    }

    public void ProcessInput()
    {
        if (focus.model != null && !ReferenceEquals(focus.model, gameObject))
            FocusRemoved();
        SetModelAsFocus();
        UpdateState();
    }

    public void ProcessInputHold()
    {
        //ProcessInput();
    }

    void UpdateState()
    {
        state++;
        if ((int)state == 6)
            state = Operation.NONE;
        focus.updateInput(state);
        Debug.Log(gameObject.name + " " + state);
    }
    void SetModelAsFocus()
    {
        focus.SetModel(gameObject);
    }
    public void FocusRemoved()
    {
        state = 0;
    }
}
