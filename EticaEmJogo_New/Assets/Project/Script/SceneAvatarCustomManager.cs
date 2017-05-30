using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneAvatarCustomManager : MonoBehaviour
{
    public PersonManager personManager;

    public GameObject poolPerson;
    public GameObject selectColor;
    public GameObject selectHair;
    public GameObject selectClothes;
    public Text playerName;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void EnterScene(string p_name)
    {
        playerName.text = p_name;
        poolPerson.SetActive(true);
        poolPerson.GetComponent<PoolPerson>().StandardPool();
    }

    public void ExitScene()
    {
        poolPerson.SetActive(false);
    }

    public void Selectcolor()
    {
        if (!selectColor.activeSelf)
            selectColor.SetActive(true);
        if (selectHair.activeSelf)
            selectHair.SetActive(false);
        if (selectClothes.activeSelf)
            selectClothes.SetActive(false);
    }

    public void SelectHair()
    {
        if (selectColor.activeSelf)
            selectColor.SetActive(false);
        if (!selectHair.activeSelf)
            selectHair.SetActive(true);
        if (selectClothes.activeSelf)
            selectClothes.SetActive(false);
    }

    public void SelectClothes()
    {
        if (selectColor.activeSelf)
            selectColor.SetActive(false);
        if (selectHair.activeSelf)
            selectHair.SetActive(false);
        if (!selectClothes.activeSelf)
            selectClothes.SetActive(true);
    }

    public void FinalizeAvatar()
    {
        ExitScene();
        personManager.ButtonViewIntructions(poolPerson.GetComponent<PoolPerson>().GetAvatarSelect());
    }
}
