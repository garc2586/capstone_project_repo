using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserBackend : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update

    public bool loginSuccess = false;
    void Start()
    {
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testuser", "1234"));
    }

    public IEnumerator GetUsers()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/Architect360Tour/GetUsers.php"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
            }
        }
    }

   public IEnumerator Login(string username, string password)
    {
        WWWForm loginForm = new WWWForm();
        loginForm.AddField("loginUser", username);
        loginForm.AddField("loginPass", password);

        using (UnityWebRequest requestLogin = UnityWebRequest.Post("http://localhost/Architect360Tour/Login.php", loginForm))
        {
            yield return requestLogin.SendWebRequest();

            if (requestLogin.isNetworkError || requestLogin.isHttpError)
            {
                Debug.Log(requestLogin.error);
            }
            else
            {
                Debug.Log(requestLogin.downloadHandler.text);
                loginSuccess = true;
            }
        }
    }
}
