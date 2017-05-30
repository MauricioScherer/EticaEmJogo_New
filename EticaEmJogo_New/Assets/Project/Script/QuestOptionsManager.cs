using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestOptionsManager : MonoBehaviour
{
    public GameManager player;
    public Text[] options;
    public Color standard;
    public Color stay;

    public void EnterQuest(int p_option)
    {
        options[p_option].color = stay;
    }
    public void ExitQuest(int p_option)
    {
        options[p_option].color = standard;
    }

    public void WalletCorrect(bool p_isCorrect)
    {
        player.player.deliverWallet = p_isCorrect;
        player.SetNumberQuestResolve(10);
    }
}
