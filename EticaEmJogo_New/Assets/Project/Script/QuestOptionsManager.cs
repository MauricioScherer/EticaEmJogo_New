using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestOptionsManager : MonoBehaviour
{
    public GameManager gameManager;
    public Text[] options;
    public Color standard;
    public Color stay;

    public void CorrectAnswer()
    {
        gameManager.CheckQuest(5);
    }

    public void RightAnswer()
    {
        gameManager.CheckQuest(2);
    }

    public void WrongAnswer()
    {
        gameManager.CheckQuest(0);
    }

    public void EnterQuest(int p_option)
    {
        if (!gameManager.isPlayEffect())
            gameManager.PlayEffect(1);
        options[p_option].color = stay;
    }
    public void ExitQuest(int p_option)
    {
        options[p_option].color = standard;
    }

    public void WalletCorrect(bool p_isCorrect)
    {
        if (p_isCorrect == false)
            gameManager.ResetMissionText();
        gameManager.player.deliverWallet = p_isCorrect;
    }
}
