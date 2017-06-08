using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonManager : MonoBehaviour
{
    private bool _RegisteredPlayer;
    private string _nameTemp;
    private string _cpfTemp;
    private int _avatarTemp;
    private bool _saveNewPlayer;

    public SceneAdminManager adminManager;
    public SceneDadosPlayerManager dadosPlayerManager;
    public SceneLoginManager loginManager;
    public SceneAvatarCustomManager avatarCustomManager;
    public SceneStatusPlayerManager statusPlayerManager;
    public GameObject[] scene;

    public string[] nameplayerArray;
    public string[] cpfplayerArray;
    public int[] avatarPlayerArray;
    public int[] pointsPlayerArray;
    public GameObject[] poolAvatar;

    void Awake()
    {
        LoadArrayPlayers();
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Home))
        {
            nameplayerArray = new string[20];
            cpfplayerArray = new string[20];
            avatarPlayerArray = new int[20];
            pointsPlayerArray = new int[20];
            for(int i = 0; i < cpfplayerArray.Length; i++)
            {
                nameplayerArray[i] = "name";
                cpfplayerArray[i] = "0";
                avatarPlayerArray[i] = 99;
                pointsPlayerArray[i] = 0;
            }
            PlayerPrefsUtility.SetStringArray("cpfArray", cpfplayerArray);
            PlayerPrefsUtility.SetStringArray("nameArray", nameplayerArray);
            PlayerPrefsUtility.SetIntArray("avatarArray", avatarPlayerArray);
            PlayerPrefsUtility.SetIntArray("pointsArray", pointsPlayerArray);
        }
	}

    public void LoginAcess()
    {
        scene[3].SetActive(false);
        scene[1].SetActive(true);
        adminManager.Initialize();
    }

    public void IntroAvatarCustom(string p_cpf, string p_name)
    {
        scene[2].SetActive(false);
        scene[4].SetActive(true);
        avatarCustomManager.EnterScene(p_name);
        _nameTemp = p_name;
        _cpfTemp = p_cpf;
    }

    public void SavePlayer()
    {        
        for (int i = 0; i < cpfplayerArray.Length; i++)
        {
            if(cpfplayerArray[i] == "0" || cpfplayerArray[i] == _cpfTemp)
            {
                cpfplayerArray[i] = _cpfTemp;
                nameplayerArray[i] = _nameTemp;
                avatarPlayerArray[i] = _avatarTemp;
                PlayerPrefsUtility.SetStringArray("cpfArray", cpfplayerArray);
                PlayerPrefsUtility.SetStringArray("nameArray", nameplayerArray);
                PlayerPrefsUtility.SetIntArray("avatarArray", avatarPlayerArray);
                PlayerPrefsUtility.SetIntArray("pointsArray", pointsPlayerArray);
                PlayerPrefs.SetInt("avatarSelect", avatarPlayerArray[i]);
                PlayerPrefs.SetString("cpfSelect", cpfplayerArray[i]);
                PlayerPrefs.SetString("nameSelect", nameplayerArray[i]);
                PlayerPrefs.SetInt("pointsSelect", pointsPlayerArray[i]);
                dadosPlayerManager.SetvalueInputs();
                break;
            }
        }
    }

    void LoadArrayPlayers()
    {
        cpfplayerArray = PlayerPrefsUtility.GetStringArray("cpfArray");
        nameplayerArray = PlayerPrefsUtility.GetStringArray("nameArray");
        avatarPlayerArray = PlayerPrefsUtility.GetIntArray("avatarArray");
        pointsPlayerArray = PlayerPrefsUtility.GetIntArray("pointsArray");
        PlayerPrefs.SetInt("avatarSelect", 0);
        PlayerPrefs.SetString("cpfSelect", "");
        PlayerPrefs.SetString("nameSelect", "");
        PlayerPrefs.SetInt("pointsSelect", 0);
    }

    public void SelectStatusPlayer(int p_numberPlayerArray)
    {
        scene[1].SetActive(false);
        scene[7].SetActive(true);
        statusPlayerManager.SetStatus(cpfplayerArray[p_numberPlayerArray], nameplayerArray[p_numberPlayerArray], pointsPlayerArray[p_numberPlayerArray], avatarPlayerArray[p_numberPlayerArray]);
    }

    public void ReturnAdminScreen()
    {
        scene[1].SetActive(true);
        scene[7].SetActive(false);
        adminManager.Initialize();
    }

    public void DeletePerfilArray(string p_cpf)
    {
        for (int i = 0; i < cpfplayerArray.Length; i++)
        {
            if (i < cpfplayerArray.Length - 1)
            {
                if (cpfplayerArray[i] == p_cpf || cpfplayerArray[i] == "0")
                {
                    cpfplayerArray[i] = cpfplayerArray[i + 1];
                    nameplayerArray[i] = nameplayerArray[i + 1];
                    avatarPlayerArray[i] = avatarPlayerArray[i + 1];
                    pointsPlayerArray[i] = pointsPlayerArray[i + 1];

                    nameplayerArray[i + 1] = "name";
                    cpfplayerArray[i + 1] = "0";
                    avatarPlayerArray[i + 1] = 99;
                    pointsPlayerArray[i + 1] = 0;
                }
            }
        }
        PlayerPrefsUtility.SetStringArray("cpfArray", cpfplayerArray);
        PlayerPrefsUtility.SetStringArray("nameArray", nameplayerArray);
        PlayerPrefsUtility.SetIntArray("avatarArray", avatarPlayerArray);
        PlayerPrefsUtility.SetIntArray("pointsArray", pointsPlayerArray);
        LoadArrayPlayers();
    }

    public void ButtonPlay()
    {
        scene[0].SetActive(false);
        scene[2].SetActive(true);
    }

    public void ButtonAdmin()
    {
        scene[0].SetActive(false);
        scene[3].SetActive(true);
    }

    public void ButtonCheckLogin()
    {
        loginManager.CheckInputs();
    }

    public void ButtonCheckPlayer()
    {
        dadosPlayerManager.CheckInputs();
    }

    public void ButtonBackToMenu()
    {
        scene[0].SetActive(true);
        if(scene[1].activeSelf)
            scene[1].SetActive(false);
        if (scene[2].activeSelf)
            scene[2].SetActive(false);
        if (scene[3].activeSelf)
            scene[3].SetActive(false);
        if (scene[4].activeSelf)
            scene[4].SetActive(false);
        if (scene[5].activeSelf)
            scene[5].SetActive(false);
        avatarCustomManager.ExitScene();
        dadosPlayerManager.SetvalueInputs();
        loginManager.SetvalueInputs();
    }

    public void ButtonCredits()
    {
        scene[0].SetActive(false);
        scene[5].SetActive(true);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonViewIntructions(int p_numAvatarSelect)
    {
        scene[4].SetActive(false);
        scene[6].SetActive(true);
        _avatarTemp = p_numAvatarSelect;
        SavePlayer();
    }

    public void ButtonPlayGame()
    {
        SceneManager.LoadScene("Scene_01");
    }
}
