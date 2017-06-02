using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevel : MonoBehaviour
{
    public GameManager gameManager;
    public int numberScene;

    void Awake()
    {
        numberScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void SetEvent(int p_numberQuestCurrent)
    {
        if(numberScene == 1)
        {
            if(p_numberQuestCurrent == 0)
            {
                gameManager.SelectMensagePhone(p_numberQuestCurrent, 13);
            }
            else if (p_numberQuestCurrent == 1)
            {
                gameManager.SelectMensagePhone(p_numberQuestCurrent, 8);
                Invoke("SelectEventGameManager", 16);
            }
        }
    }

    void SelectEventGameManager()
    {
        if (numberScene == 1)
        {
            gameManager.SelectQuest(2);
        }
    }
}
