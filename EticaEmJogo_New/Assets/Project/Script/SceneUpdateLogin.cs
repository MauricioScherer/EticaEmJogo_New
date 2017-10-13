using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneUpdateLogin : MonoBehaviour
{
    public PersonManager manager;
    public InputField login;
    public InputField password;
    public GameObject alert;

    public void UpdateLogin()
    {
        if(login.text != "" && password.text != "")
        {
            PlayerPrefs.SetString("loginAdmin", login.text);
            PlayerPrefs.SetString("passwordAdmin", password.text);
            login.text = "";
            password.text = "";
            alert.SetActive(false);
            manager.ButtonExitUpdateLogin();
        }
        else
        {
            alert.SetActive(true);
        }
    }
}
