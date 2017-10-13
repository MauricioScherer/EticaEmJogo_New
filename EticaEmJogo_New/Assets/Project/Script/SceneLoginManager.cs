using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoginManager : MonoBehaviour
{
    public PersonManager personManager;

    public string login;
    public string password;
    public InputField inputLogin;
    public InputField inputPassword;
    public GameObject[] warning;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public string GetLogin()
    {
        return inputLogin.text;
    }

    public string GetPassword()
    {
        return inputPassword.text;
    }

    public void SetvalueInputs()
    {
        inputLogin.text = "";
        inputPassword.text = "";
        if (warning[0].activeSelf)
            warning[0].SetActive(false);
        if (warning[1].activeSelf)
            warning[1].SetActive(false);
        if (warning[2].activeSelf)
            warning[2].SetActive(false);
    }

    public void CheckInputs()
    {
        if (GetLogin() == "" && GetPassword() != "")
        {
            warning[0].SetActive(true);
            warning[1].SetActive(false);
            if (warning[2].activeSelf)
                warning[2].SetActive(false);
        }
        else if (GetLogin() != "" && GetPassword() == "")
        {
            warning[0].SetActive(false);
            warning[1].SetActive(true);
            if (warning[2].activeSelf)
                warning[2].SetActive(false);
        }
        else if (GetLogin() == "" && GetPassword() == "")
        {
            warning[0].SetActive(true);
            warning[1].SetActive(true);
            if (warning[2].activeSelf)
                warning[2].SetActive(false);
        }
        else if(GetLogin() == login && GetPassword() == password)
        {
            CheckStatusLogin();
        }
        else if(PlayerPrefs.HasKey("loginAdmin"))
        {
            if(GetLogin() == PlayerPrefs.GetString("loginAdmin") && GetPassword() == PlayerPrefs.GetString("passwordAdmin"))
            {
                CheckStatusLogin();
            }
        }
        else
        {
            warning[2].SetActive(true);
        }
    }

    void CheckStatusLogin()
    {
        warning[0].SetActive(false);
        warning[1].SetActive(false);
        if (warning[2].activeSelf)
            warning[2].SetActive(false);
        SetvalueInputs();
        personManager.LoginAcess();
    }
}
