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
    public Text quest2;
    public Text quest3;
    public Text quest4;
    public GameObject buttonInviteQuest;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(_stayInQuest)
        {
            if(quest1.text != "" && quest2.text != "" && quest3.text != "" && quest4.text != "")
            {
                if(!buttonInviteQuest.activeSelf)
                    buttonInviteQuest.SetActive(true);
            }
            else
            {
                if (buttonInviteQuest.activeSelf)
                    buttonInviteQuest.SetActive(false);
            }
        }
    }

    public void ViewCanvasQuest()
    {
        canvasQuest.SetActive(true);
        _stayInQuest = true;
    }

    public void RegisterAnswer()
    {
        int tempSize = PlayerPrefsUtility.GetStringArray("cpfArray").Length;
        string[] tempArray = PlayerPrefsUtility.GetStringArray("answerArray");

        for(int i = 0; i < tempSize; i++)
        {
            if(tempArray[i] == "Active")
            {
                tempArray[i] = "O que o jogo significou pra você? \n" + quest1.text + "\n";
                tempArray[i] += "O que você aprendeu com este jogo? \n" + quest2.text + "\n";
                tempArray[i] += "O que você achou do jogo? \n" + quest3.text + "\n";
                tempArray[i] += "O que você pode tirar de bom deste jogo? \n" + quest4.text;
                PlayerPrefsUtility.SetStringArray("answerArray", tempArray);
                break;
            }
        }
        SceneManager.LoadScene("Menu");
    }
}
