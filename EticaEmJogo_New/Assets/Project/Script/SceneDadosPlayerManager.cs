using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneDadosPlayerManager : MonoBehaviour
{
    public PersonManager personManager;

    public InputField inputNamePlayer;
    public InputField inputCpfPlayer;
    public GameObject[] warning;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public string GetNamePlayer()
    {
        return inputNamePlayer.text;
    }

    public string GetCpfPlayer()
    {
        return inputCpfPlayer.text;
    }

    public void SetvalueInputs()
    {
        inputNamePlayer.text = "";
        inputCpfPlayer.text = "";
        if (warning[0].activeSelf)
            warning[0].SetActive(false);
        if (warning[1].activeSelf)
            warning[1].SetActive(false);
    }

    public void CheckInputs()
    {
        if (GetCpfPlayer() == "" && GetNamePlayer() != "")
        {
            warning[0].SetActive(true);
            warning[1].SetActive(false);
        }
        else if (GetCpfPlayer() != "" && GetNamePlayer() == "")
        {
            warning[0].SetActive(false);
            warning[1].SetActive(true);
        }
        else if (GetCpfPlayer() == "" && GetNamePlayer() == "")
        {
            warning[0].SetActive(true);
            warning[1].SetActive(true);
        }
        else
        {
            warning[0].SetActive(false);
            warning[1].SetActive(false);
            personManager.IntroAvatarCustom(GetCpfPlayer(), GetNamePlayer());
            //personManager.SavePlayer(GetCpfPlayer(), GetNamePlayer());
        }
    }
}
