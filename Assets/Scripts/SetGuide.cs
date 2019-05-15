using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGuide : MonoBehaviour
{
    public List<GameObject> guideAnchors;
    GameObject active;

    public void GuideState(Operation state)
    {
        if (active != null)
            active.SetActive(false);
        if (guideAnchors[(int)state] != null)
        {
            guideAnchors[(int)state].SetActive(true);
            active = guideAnchors[(int)state];
            active.transform.localRotation = Quaternion.Inverse(gameObject.transform.rotation);
        }
    }
}
