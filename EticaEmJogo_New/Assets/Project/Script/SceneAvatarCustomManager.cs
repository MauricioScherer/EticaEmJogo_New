using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneAvatarCustomManager : MonoBehaviour
{
    public PersonManager personManager;

    public GameObject poolPerson;
    public Text playerName;
    public GameObject mensageSelectAvatar;
    public GameObject buttonPlay;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void EnterScene(string p_name)
    {
        playerName.text = p_name;
        ViewMensageSelectAvatar(true);
    }

    public void ExitScene()
    {
        poolPerson.GetComponent<PoolPerson>().ResetPool();
        ViewMensageSelectAvatar(true);
    }

    public void FinalizeAvatar()
    {
        ExitScene();
        personManager.ButtonViewIntructions(poolPerson.GetComponent<PoolPerson>().GetAvatarSelect());
    }

    public void ViewMensageSelectAvatar(bool p_status)
    {
        mensageSelectAvatar.SetActive(p_status);
        buttonPlay.SetActive(!p_status);
    }
}
