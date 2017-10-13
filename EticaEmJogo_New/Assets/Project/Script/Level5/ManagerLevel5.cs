using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerLevel5 : MonoBehaviour
{
    private bool _stayInQuest;
    public GameObject canvasQuest;
    public Text quest1;
    public GameObject buttonInviteQuest;
    public GameObject ballonDialogueGod;
    public GameObject ballonDialogueBad;
    public Text numCaracter;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(_stayInQuest)
        {
            if(quest1.text.Length >= 200)
            {
                if(!buttonInviteQuest.activeSelf)
                    buttonInviteQuest.SetActive(true);
            }
            else
            {
                if (buttonInviteQuest.activeSelf)
                    buttonInviteQuest.SetActive(false);
            }

            numCaracter.text = quest1.text.Length.ToString() + " / " + "500";
        }
    }

    public void ViewCanvasQuest(bool p_status)
    {
        canvasQuest.SetActive(p_status);
        _stayInQuest = p_status;
    }

    public void RegisterAnswer()
    {
        int tempSize = PlayerPrefsUtility.GetStringArray("cpfArray").Length;
        string[] tempArray = PlayerPrefsUtility.GetStringArray("answerArray");

        for(int i = 0; i < tempSize; i++)
        {
            if(tempArray[i] == "Active")
            {
                tempArray[i] = "O que você aprendeu durante essa experiência aqui no Suprema Compra? \n" + quest1.text;
                PlayerPrefsUtility.SetStringArray("answerArray", tempArray);
                break;
            }
        }

        if(PlayerPrefs.GetInt("pointsSelect") < 39)
        {
            ballonDialogueBad.SetActive(true);
        }
        else
        {
            ballonDialogueGod.SetActive(true);
        }
        ViewCanvasQuest(false);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Scene_Anim_FinalLevel");
    }
}
