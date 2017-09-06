using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevel4 : MonoBehaviour
{
    private int _numberPag;

    public GameManager gameManager;
    public GameObject arrowJob;

    public GameObject placarFinalLevel;
    public GameObject particleFinalLevel;
    public GameObject[] medalForPoints;
    public GameObject[] exclamationAvatar;

    public GameObject feedback;
    public GameObject buttonBackPag;
    public GameObject buttonNextPag;
    public GameObject buttonContinue;
    public GameObject[] pag;
    public GameObject[] pagCurrent;

    void Start ()
    {
        if (Time.deltaTime < 1)
            Time.timeScale = 1;
        if (gameManager.player.GetCanWalk())
        {
            PlayerCanWalk(false);
        }
    }
	
	void Update ()
    {
		
	}

    public void ActiveExclamation(int p_number)
    {
        if (exclamationAvatar[p_number].activeSelf)
            exclamationAvatar[p_number].SetActive(false);
        else
            exclamationAvatar[p_number].SetActive(true);
    }

    public void ViewArrowJob()
    {
        if (!arrowJob.activeSelf)
        {
            arrowJob.SetActive(true);
        }
        else
        {
            arrowJob.SetActive(false);
        }
    }

    public void ViewPlacarFinalLevel(bool p_activate)
    {
        gameManager.player.CanWalk(false);
        placarFinalLevel.SetActive(p_activate);
        particleFinalLevel.SetActive(p_activate);
        if (p_activate)
        {
            if (gameManager.GetScore() >= 12)
                medalForPoints[0].SetActive(true);
            else if (gameManager.GetScore() >= 6)
                medalForPoints[1].SetActive(true);
            else
                medalForPoints[2].SetActive(true);
        }
        else
        {
            medalForPoints[0].SetActive(false);
            medalForPoints[1].SetActive(false);
            medalForPoints[2].SetActive(false);
        }

    }

    public void PlayerCanWalk(bool p_canwalk)
    {
        gameManager.player.CanWalk(p_canwalk);
    }

    public void ViewFeedback()
    {
        feedback.SetActive(true);
        PagDefine(gameManager.GetScore());
    }
    void PagDefine(float p_points)
    {
        if (p_points >= 12)
            pagCurrent = new GameObject[1] { pag[0] };
        else if (p_points >= 6)
            pagCurrent = new GameObject[1] { pag[1] };
        else
            pagCurrent = new GameObject[1] { pag[2] };

        if (buttonNextPag.activeSelf)
            buttonNextPag.SetActive(false);
        if (buttonBackPag.activeSelf)
            buttonBackPag.SetActive(false);
        if (!buttonContinue.activeSelf)
            buttonContinue.SetActive(true);

        pagCurrent[0].SetActive(true);
    }
    public void NextPag()
    {
        if (_numberPag < pagCurrent.Length - 1)
        {
            for (int i = 0; i < pagCurrent.Length; i++)
            {
                if (pagCurrent[i].activeSelf)
                {
                    pagCurrent[i].SetActive(false);
                    pagCurrent[i + 1].SetActive(true);
                    if (i == 0)
                    {
                        buttonBackPag.SetActive(true);
                    }
                    if (i + 1 == pagCurrent.Length - 1)
                    {
                        buttonNextPag.SetActive(false);
                        buttonContinue.SetActive(true);
                    }
                    break;
                }
            }
            _numberPag++;
        }
    }
    public void BackPag()
    {
        if (_numberPag > 0)
        {
            for (int i = 0; i < pagCurrent.Length; i++)
            {
                if (pagCurrent[i].activeSelf)
                {
                    pagCurrent[i].SetActive(false);
                    pagCurrent[i - 1].SetActive(true);
                    if (i == 1)
                    {
                        buttonBackPag.SetActive(false);
                    }
                    if (buttonContinue.activeSelf)
                    {
                        buttonContinue.SetActive(false);
                        buttonNextPag.SetActive(true);
                    }
                    break;
                }
            }
            _numberPag--;
        }
    }
    public void ButtonContinue()
    {
        string[] tempArray = new string[20];
        tempArray = PlayerPrefsUtility.GetStringArray("cpfArray");

        int[] tempPoint = new int[20];
        tempPoint = PlayerPrefsUtility.GetIntArray("pointsArray");
        for (int i = 0; i < tempArray.Length; i++)
        {
            if (tempArray[i] == PlayerPrefs.GetString("cpfSelect"))
            {
                tempPoint[i] += (int)gameManager.GetScore();
                PlayerPrefsUtility.SetIntArray("pointsArray", tempPoint);
                break;
            }
        }
        SceneManager.LoadScene("Menu");
    }
}
