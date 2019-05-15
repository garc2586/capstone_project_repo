using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardInput : MonoBehaviour
{
    RaycastHit hitLeft, hitRight;
    public GameObject cameraLeft, cameraRight;
    public ModelSpawnInput modelSpawnRoot;
    Component input;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cameraLeft.transform.position, cameraLeft.transform.forward * 10, Color.green);
        Debug.DrawRay(cameraRight.transform.position, cameraRight.transform.forward * 10, Color.red);
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(cameraLeft.transform.position, cameraLeft.transform.forward, out hitLeft) || Physics.Raycast(cameraRight.transform.position, cameraRight.transform.forward, out hitRight)) {
                modelSpawnRoot.ProcessInput(false);
                Transform hitObj = hitLeft.transform;
                Debug.Log("Ray");
                Debug.Log(hitObj.transform.tag);
                input = hitObj.transform.GetComponent<SphereChanger>();
                if (input != null)
                    hitObj.transform.GetComponent<SphereChanger>().ChangePos();
                else
                {
                    input = hitObj.transform.GetComponent<EditModel>();
                    if (input != null)
                        hitObj.transform.GetComponent<EditModel>().ProcessInput();
                    else {
                        input = hitObj.transform.GetComponent<ModelInput>();
                        if (input != null)
                            hitObj.transform.GetComponent<ModelInput>().ProcessInput();
                        else
                        {
                            modelSpawnRoot.ProcessInput(true);
                            input = hitObj.transform.GetComponent<ModelList>();
                            if (input != null)
                            {
                                modelSpawnRoot.gameObject.GetComponent<ModelSpawnRoots>().modelType.SetActive(false);
                                modelSpawnRoot.gameObject.GetComponent<ModelSpawnRoots>().modelSelection.SetActive(true);
                                hitObj.transform.GetComponent<ModelList>().ProcessInput(true);
                            }
                            else
                            {
                                input = hitObj.transform.GetComponent<SpawnModel>();
                                if (input != null)
                                {
                                    modelSpawnRoot.gameObject.GetComponent<ModelSpawnRoots>().modelSelection.SetActive(false);
                                    hitObj.transform.GetComponent<SpawnModel>().ProcessInput();
                                }
                                else
                                {
                                    modelSpawnRoot.gameObject.GetComponent<ModelSpawnRoots>().modelType.SetActive(true);
                                    Debug.Log("Defaulting to model spawn");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                modelSpawnRoot.ProcessInput(true);
                Debug.Log(modelSpawnRoot.gameObject);
                modelSpawnRoot.gameObject.GetComponent<ModelSpawnRoots>().modelType.SetActive(true);
            }
        }
        if(Input.GetMouseButton(0) && (Physics.Raycast(cameraLeft.transform.position, cameraLeft.transform.forward, out hitLeft) || Physics.Raycast(cameraRight.transform.position, cameraRight.transform.forward, out hitRight)))
        {
            input = hitLeft.transform.GetComponent<ModelInput>();
            if (input != null)
                hitLeft.transform.GetComponent<ModelInput>().ProcessInput();
        }
    }
}
