using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestOptionsManager : MonoBehaviour
{
    private bool _activeSelectQuest;

    public GameManager gameManager;
    public NpcManager avatarWallet;
    public Text[] options;
    public Color standard;
    public Color stay;

    void Start()
    {
        Invoke("ActiveSelectQuest", 1f);
    }

    public void CorrectAnswer()
    {
        if(_activeSelectQuest)
        {
            gameManager.CheckQuest(5);
            gameManager.ActiveFeedBackQuest(0);
        }
    }

    public void RightAnswer()
    {
        if (_activeSelectQuest)
        {
            gameManager.CheckQuest(2);
            gameManager.ActiveFeedBackQuest(1);
        }
    }

    public void WrongAnswer()
    {
        if (_activeSelectQuest)
        {
            gameManager.CheckQuest(0);
            gameManager.ActiveFeedBackQuest(2);
        }
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
        if (_activeSelectQuest)
        {
            if (p_isCorrect == false)
            {
                gameManager.ResetMissionText();
                if(avatarWallet)
                    avatarWallet.questResolved = true;
            }
            gameManager.player.deliverWallet = p_isCorrect;
        }
    }

    void ActiveSelectQuest()
    {
        _activeSelectQuest = true;
    }

    public bool GetActiveSelectQuest()
    {
        return _activeSelectQuest;
    }
}
