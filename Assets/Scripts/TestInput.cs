using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{

    public List<GameObject> furniture;

    static TransformModel trans = null;

    void Start()
    {
        if (trans == null)
            trans = GameObject.FindGameObjectWithTag("Input").GetComponent<TransformModel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Comma))
            trans.LeftMove();
        if(Input.GetKey(KeyCode.Period))
            trans.RightMove();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameObject.GetComponent<SpawnModel>().Create(furniture[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.GetComponent<SpawnModel>().Create(furniture[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameObject.GetComponent<SpawnModel>().Create(furniture[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gameObject.GetComponent<SpawnModel>().Create(furniture[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            gameObject.GetComponent<SpawnModel>().Create(furniture[4]);
        }
    }
}
