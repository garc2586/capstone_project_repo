using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackendInstance : MonoBehaviour
{
    public static BackendInstance Instance;

    public UserBackend userBackend;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        userBackend = GetComponent<UserBackend>();
    }

}  
