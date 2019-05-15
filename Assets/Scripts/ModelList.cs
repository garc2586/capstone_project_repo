using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelList : MonoBehaviour
{
    public List<GameObject> models;

    public static GameObject modelSpawns;
    static GameObject player;

    private void Start()
    {
        if(modelSpawns == null)
        {
            modelSpawns = GameObject.FindGameObjectWithTag("ModelSpawn");
            modelSpawns.SetActive(false);
        }
        if (player == null)
            player = GameObject.FindGameObjectWithTag("PlayerLoc");
        if(models.Count == 0)
        {
            Debug.Log(gameObject.name + " has no models");
        }
        for(int i = 0; i < models.Count; i++)
        {
            if (models[i] == null)
            {
                Debug.Log(gameObject.name + " has null model");
                return;
            }
        }
    }

    public void ProcessInput(bool on)
    {
        //gameObject.transform.position = player.transform.position + (player.transform.forward * 0.5f);
        Debug.Log(player.transform.position + (player.transform.forward * 3f));
        Debug.Log(player.name);
        gameObject.transform.LookAt(player.transform.position);
        for (int i = 0; i < 3; i++)
        {
            Transform currModel = modelSpawns.transform.GetChild(i);
            Debug.Log(modelSpawns.transform.GetChild(i).GetComponent<SpawnModel>());
            currModel.GetComponent<SpawnModel>().SetModel(models[i]);
            Instantiate(models[i], currModel);
            currModel.GetChild(0).transform.localPosition = Vector3.zero;
            //currModel.GetChild(0).transform.LookAt(player.transform.position);
            currModel.GetChild(0).localRotation = Quaternion.Euler(90f, 90f, 90f);
        }
    }


}
