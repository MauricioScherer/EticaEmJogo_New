using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevel : MonoBehaviour
{
    private int _numberScene;
    private int _numberQuestResolve;
    
    public GameManager gameManager;
    public GameObject triggerInstruction2;
    public GameObject canvasInstruction;
    public GameObject painel;
    public GameObject alertFinalLevel;
    public GameObject[] instruction;

    void Awake()
    {
        _numberScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        if(canvasInstruction)
        {
            canvasInstruction.SetActive(true);
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
                Invoke("SelectEventGameManager", 15);
            }
            else if(_numberQuestResolve == 2)
            {
                Invoke("viewAlertFinalLevel", 8);
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
        canvasInstruction.SetActive(true);
        alertFinalLevel.SetActive(true);
        Invoke("ResetAlert", 5);
    }

    void ResetAlert()
    {
        alertFinalLevel.SetActive(false);
        canvasInstruction.SetActive(false);
    }

    public void NewInstruction()
    {
        canvasInstruction.SetActive(true);
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
        canvasInstruction.SetActive(false);
        Time.timeScale = 1;
    }

    public bool ResolveTotalQuests()
    {
        if (_numberQuestResolve == 3)
            return true;
        else
            return false;
    }
}
