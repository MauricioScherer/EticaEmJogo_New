using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameManager gameManager;
    public ManagerLevel managerLevel;
    public ManagerLevel2 managerLevel2;
    public NpcDialogue1 npcDialogue;
    public GameObject[] npcsDeactive;
    private bool _viewBallon;

    void OnTriggerEnter(Collider other)
    {
        if(gameManager.GetNumberScene() == 1)
        {
            if (other.CompareTag("Player"))
            {
                if (gameObject.CompareTag("TriggerAction"))
                {
                    if (managerLevel.ResolveTotalQuests())
                    {
                        //TODO 
                        //chama o feedback level anterior sem a premiação de level                  
                        //managerLevel.FadeIn();
                        //gameObject.SetActive(false);

                        managerLevel.FadeMusic();
                        managerLevel.ViewPlacarFinalLevel(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    managerLevel.NewInstruction();
                    gameObject.SetActive(false);
                }
            }
        }
        else if(gameManager.GetNumberScene() == 3)
        {
            if (other.CompareTag("Player"))
            {
                if (gameObject.CompareTag("TriggerAction"))
                {
                    if(gameManager.numberQuestResolve == 3 && !_viewBallon)
                    {
                        for(int i = 0; i < npcsDeactive.Length; i++)
                        {
                            npcsDeactive[i].SetActive(false);
                        }
                        managerLevel2.ViewArrow(false);
                        gameManager.player.SetNewPositionPlayewr(gameObject.transform);
                        gameManager.player.CanWalk(false);
                        Invoke("SetRotationPLayer", 2);
                        gameManager.help.SetActive(false);
                        gameManager.phone.SetActive(false);
                        _viewBallon = true;
                    }
                }
            }
        }
    }

    void SetRotationPLayer()
    {
        npcDialogue.ViewBallonDialogueInitial();
        gameManager.ResetMissionText();
        gameManager.player.gameObject.transform.rotation = gameObject.transform.rotation;
    }
}