using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSpawnInput : MonoBehaviour
{
    public GameObject spawnMenuRoot;
    public GameObject player;

    public void ProcessInput(bool enable)
    {
        spawnMenuRoot.SetActive(enable);
        if (enable)
        {
            spawnMenuRoot.transform.position = player.transform.position + (player.transform.forward * 0.5f);
            spawnMenuRoot.transform.LookAt(player.transform.position);
            //spawnMenuRoot.transform.Translate(Vector3.up * 1.2f);
            //spawnMenuRoot.transform.RotateAround(player.transform.position, Vector3.up, 90.0f);
        }
    }
}
