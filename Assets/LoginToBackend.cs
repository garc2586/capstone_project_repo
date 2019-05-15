using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginToBackend : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(() => {
           StartCoroutine(BackendInstance.Instance.userBackend.Login(usernameInput.text, passwordInput.text));
            if(BackendInstance.Instance.userBackend.loginSuccess == true)
            {
                SceneManager.LoadScene("cube");
            }
        });
    }

   
}
