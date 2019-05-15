using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DynamicTexture : MonoBehaviour
{
    public Material currentRoom;
    public Texture currentRoomTexture;
    public string veniceTextureURL = "https://roadtovrlive-5ea0.kxcdn.com/wp-content/uploads/2014/09/Venice.Still001.jpeg";


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTexture());

    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(veniceTextureURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            this.GetComponent<MeshRenderer>().material.mainTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
