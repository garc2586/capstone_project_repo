using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModel : MonoBehaviour
{
    public GameObject modelSpawn;

    static GameObject player;

    public void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("PlayerLoc");
        }
    }

    public void SetModel(GameObject model)
    {
        modelSpawn = model;
    }

    public void ProcessInput()
    {
        Create(modelSpawn);
    }

    public void Spawn()
    {
        Create(modelSpawn);
    } 
    public void Create(GameObject obj)
    {
        GameObject spawn;
        spawn = Instantiate(obj);
        Debug.Log(player.name);
        spawn.transform.position = player.transform.position + (player.transform.forward * 3f);
        Debug.Log(player.transform.position + (player.transform.forward * 3f));
    }
}
