using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBallon : MonoBehaviour
{
    public GameManager gameManager;
    public NpcManager npcManager;
    public GameObject[] textDialogue;

    public void ConfirmDialogue()
    {
        for(int i = 0; i < textDialogue.Length; i++)
        {
            if(i < textDialogue.Length - 1)
            {
                if (textDialogue[i].activeSelf)
                {
                    textDialogue[i].SetActive(false);
                    textDialogue[i + 1].SetActive(true);
                    break;
                }
            }
            else
            {
                npcManager.SetStandardAnim();               

                if (gameManager.GetNumberScene() == 2)
                {
                    if (gameManager.numberQuestResolve == 0)
                    {
                        gameManager.SelectQuest(3);
                        gameManager.player.CanWalk(false);
                    }
                    else
                    {
                        gameManager.player.SetValues();
                    }
                }

                gameObject.SetActive(false);
            }
        }
    }
}
