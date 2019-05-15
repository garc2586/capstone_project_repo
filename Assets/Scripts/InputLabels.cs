using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLabels : MonoBehaviour
{
    public TextMesh leftText, rightText;

    public void setLeftLabel(string s)
    {
        leftText.text = s;
    }
    public void setRightLabel(string s)
    {
        rightText.text = s;
    }
}
