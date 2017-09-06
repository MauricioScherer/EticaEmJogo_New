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
                    if(!npcManager.GetComponent<AudioSource>().isPlaying)
                        npcManager.GetComponent<AudioSource>().Play();
                    break;
                }
            }
            else
            {
                npcManager.SetStandardAnim();               

                if (gameManager.GetNumberScene() == 3)
                {
                    if (gameManager.numberQuestResolve == 0)
                    {
                        gameManager.SelectQuest(3);
                        gameManager.managerLevel2.quest1Resolve = true;                        
                        gameManager.player.CanWalk(false);
                    }
                    else if (gameManager.numberQuestResolve == 1)
                    {
                        gameManager.player.SetValues();
                        gameManager.ResetMissionText();
                        gameManager.managerLevel2.SetNumberQuest(2);
                        gameManager.numberQuestResolve = 2;
                        gameManager.SetMissionText();
                    }
                    else if (gameManager.numberQuestResolve == 2)
                    {
                        gameManager.player.SetValues();
                        gameManager.ResetMissionText();
                        gameManager.managerLevel2.SetNumberQuest(3);
                        gameManager.numberQuestResolve = 3;
                        gameManager.SetMissionText();
                        gameManager.managerLevel2.ViewArrow(true);
                    }
                }
                else if(gameManager.GetNumberScene() == 4)
                {
                    if (gameManager.numberQuestResolve == 0 && !gameManager.managerLevel3.finalizeIntroDialogue)
                    {
                        if (gameManager.managerLevel3.npcManager1.ballonDialogue[0].activeSelf)
                        {
                            gameManager.managerLevel3.FinalizeIntroDialogueLevel();
                            gameManager.ResetMissionText();
                            gameManager.SetMissionText();                            
                        }
                        else
                        {
                            gameManager.managerLevel3.npcManager1.ballonDialogue[0].SetActive(true);
                        }
                    }
                    else if(gameManager.numberQuestResolve == 1)
                    {
                        gameManager.player.SetValues();
                        gameManager.ResetMissionText();
                        gameManager.managerLevel3.ViewArrowJob();
                    }
                    else if(gameManager.numberQuestResolve == 6)
                    {
                        gameManager.managerLevel3.ViewPlacarFinalLevel(true);
                    }
                }
                else if(gameManager.GetNumberScene() == 5)
                {
                    if (gameManager.numberQuestResolve == 0)
                    {
                        gameManager.managerLevel4.PlayerCanWalk(true);
                        gameManager.managerLevel4.ActiveExclamation(0);
                    }
                    else if(gameManager.numberQuestResolve == 1)
                    {
                        gameManager.managerLevel4.ViewArrowJob();
                        gameManager.player.SetValues();
                    }
                }

                gameObject.SetActive(false);
            }
        }
    }
}
