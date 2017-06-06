using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevel : MonoBehaviour
{
    private int _numberScene;
    private int _numberQuestResolve;
    private int _numberPag;
    
    public GameManager gameManager;
    public GameObject busFinalLevel;
    public GameObject triggerInstruction2;
    public GameObject canvasInstruction;
    public GameObject painel;
    public GameObject alertFinalLevel;    
    public GameObject[] instruction;

    public GameObject feedback;
    public GameObject buttonBackPag;
    public GameObject buttonNextPag;
    public GameObject buttonContinue;
    public GameObject[] pag;
    public GameObject[] pagCurrent;

    void Awake()
    {
        _numberScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        if(canvasInstruction)
        {
            painel.SetActive(true);
            instruction[0].SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SetEvent(int p_numberQuestCurrent)
    {
        if(_numberScene == 1)
        {
            _numberQuestResolve = p_numberQuestCurrent;
            if (_numberQuestResolve == 0)
            {
                gameManager.SelectMensagePhone(_numberQuestResolve, 13);
            }
            else if (_numberQuestResolve == 1)
            {
                gameManager.SelectMensagePhone(_numberQuestResolve, 8);
                Invoke("SelectEventGameManager", 17);
            }
            else if(_numberQuestResolve == 2)
            {
                Invoke("viewAlertFinalLevel", 6);
            }
        }
    }

    void SelectEventGameManager()
    {
        if (_numberScene == 1)
        {
            gameManager.player.CanWalk();
            gameManager.SelectQuest(2);
        }
    }

    void viewAlertFinalLevel()
    {
        alertFinalLevel.SetActive(true);
        busFinalLevel.SetActive(true);
        PagDefine(gameManager.GetScore());
        Invoke("ResetAlert", 5);
    }

    void ResetAlert()
    {
        alertFinalLevel.SetActive(false);
    }

    public void NewInstruction()
    {
        painel.SetActive(true);
        instruction[1].SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnToGame()
    {
        for(int i = 0; i < instruction.Length; i++)
        {
            instruction[i].SetActive(false);
        }
        painel.SetActive(false);
        Time.timeScale = 1;
    }

    public bool ResolveTotalQuests()
    {
        if (_numberQuestResolve == 2)
            return true;
        else
            return false;
    }

    public void ViewFeedback()
    {        
        feedback.SetActive(true);        
        Time.timeScale = 0;
    }

    void PagDefine(float p_points)
    {
        if (p_points >= 12)
            pagCurrent = new GameObject[3] {pag[0],pag[1], pag[2] };
        else if(p_points >= 6)
            pagCurrent = new GameObject[3] { pag[0], pag[1], pag[3] };
        else
            pagCurrent = new GameObject[4] { pag[0], pag[1], pag[4],pag[5] };
    }

    public void NextPag()
    {
        if(_numberPag < pagCurrent.Length - 1)
        {
            for (int i = 0; i < pagCurrent.Length; i++)
            {
                if(pagCurrent[i].activeSelf)
                {
                    pagCurrent[i].SetActive(false);
                    pagCurrent[i + 1].SetActive(true);
                    if(i == 0)
                    {
                        buttonBackPag.SetActive(true);
                    }
                    if(i + 1 == pagCurrent.Length - 1)
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
                    if(buttonContinue.activeSelf)
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
            if(tempArray[i] == PlayerPrefs.GetString("cpfSelect"))
            {
                tempPoint[i] = (int)gameManager.GetScore();
                PlayerPrefsUtility.SetIntArray("pointsArray", tempPoint);
                break;
            }
        }
        SceneManager.LoadScene("Menu");
    }
}
