﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLevel3 : MonoBehaviour
{
    public bool finalizeIntroDialogue;
    public bool getEpi;
    public bool dialogueNpcPedro;
    public GameManager gameManager;
    public NpcManager npcManager1;
    public GameObject arrowLockers;
    public GameObject arrowJog;
    public GameObject epiImage;
    public ManagerJodLevel3 managerJob;
    public GameObject NpcChico;
    public GameObject WokTok;
    public GameObject DialogueWokTok_1;

    void Start()
    {
        if(gameManager.player.GetCanWalk())
        {
            gameManager.player.CanWalk(false);
        }
    }

    public void FinalizeIntroDialogueLevel()
    {
        npcManager1.ballonDialogue[0].SetActive(false);
        finalizeIntroDialogue = true;
        gameManager.player.CanWalk(true);
        ViewArrowLockers();
    }

    public void ViewArrowLockers()
    {
        if(!arrowLockers.activeSelf)        
            arrowLockers.SetActive(true);        
        else        
            arrowLockers.SetActive(false);        
    }

    public void ViewArrowJob()
    {
        if (!arrowJog.activeSelf)
        {
            arrowJog.SetActive(true);
        }
        else
        {
            gameManager.player.CanWalk(false);
            arrowJog.SetActive(false);
        }        
    }

    public void ViewEpiMensage()
    {
        gameManager.player.CanWalk(false);
        gameManager.numberQuestResolve = 1;
        epiImage.SetActive(true);
    }

    public void DeactiveEpiMensage()
    {
        Invoke("ActiveWalkPlayer", 0.1f);
        gameManager.ResetMissionText();
        gameManager.SetMissionText();
        epiImage.SetActive(false);
    }

    void ActiveWalkPlayer()
    {
        gameManager.player.CanWalk(true);
    }

    public void SelectQuest(int p_numberQuest)
    {
        gameManager.SelectQuest(p_numberQuest);
    }

    public void InitializeJob()
    {
        managerJob.EnterNewBox();
    }

    public void InvokeNpcChico()
    {
        NpcChico.SetActive(true);
    }

    public void AnimWokTok()
    {
        WokTok.GetComponent<AudioSource>().Play();
        WokTok.GetComponent<Animator>().SetBool("ActiveWalk", true);
        DialogueWokTok_1.SetActive(true);
        Invoke("ResetAnimWokTok", 0.2f);
        Invoke("ResetDialogueWokTok", 6f);
    }
    void ResetAnimWokTok()
    {
        WokTok.GetComponent<Animator>().SetBool("ActiveWalk", false);
    }
    void ResetDialogueWokTok()
    {
        InitializeJob();
        DialogueWokTok_1.SetActive(false);
    }
}
