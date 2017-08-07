﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerLevel3 : MonoBehaviour
{
    private bool _enterRefactory;
    private bool _fadeIn;
    private bool _fadeOut;
    private bool _fadeMusic;
    private Color _colorFade;

    public bool finalizeIntroDialogue;
    public bool getEpi;
    public bool dialogueNpcPedro;
    public GameManager gameManager;
    public NpcManager npcManager1;
    public GameObject arrowLockers;
    public GameObject arrowJog;
    public GameObject arrowRefactory;
    public GameObject epiImage;
    public GameObject epiImageEmpty;
    public ManagerJodLevel3 managerJob;
    public ManagerJod2Level3 managerJob2;
    public GameObject NpcChico;
    public GameObject NpcSandro;
    public GameObject WokTok;
    public GameObject DialogueWokTok_1;
    public GameObject DialogueWokTok_2;
    public GameObject DialogueWokTok_3;
    public GameObject DialogueWokTok_4;
    public Image fade;
    public GameObject textFade;

    void Start()
    {
        if(gameManager.player.GetCanWalk())
        {
            PlayerCanWalk(false);
        }
    }

    void Update()
    {
        if (_fadeIn)
        {
            fade.color = _colorFade;
            _colorFade.a += 0.6f * Time.deltaTime;

            if (_colorFade.a >= 1)
            {
                textFade.SetActive(true);
                Invoke("FadeOut", 3f);
                _fadeIn = false;
            }
        }
        if (_fadeOut)
        {
            fade.color = _colorFade;
            _colorFade.a -= 0.6f * Time.deltaTime;

            if (_colorFade.a <= 0)
            {
                fade.gameObject.SetActive(false);
                textFade.SetActive(false);

                if(gameManager.numberQuestResolve == 2)
                {
                    gameManager.player.CanWalk(true);
                    gameManager.ResetMissionText();
                    gameManager.numberQuestResolve++;
                    gameManager.SetMissionText();                    
                    ViewArrowLockers();
                }
                _fadeOut = false;
            }
        }
    }

    public void FinalizeIntroDialogueLevel()
    {
        npcManager1.ballonDialogue[0].SetActive(false);
        finalizeIntroDialogue = true;
        PlayerCanWalk(true);
        ViewArrowLockers();
    }

    public void PlayerCanWalk(bool p_canwalk)
    {
        gameManager.player.CanWalk(p_canwalk);
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
            PlayerCanWalk(false);
            arrowJog.SetActive(false);
        }        
    }

    public void ViewArrowRefactory()
    {
        if (!arrowRefactory.activeSelf)
        {
            arrowRefactory.SetActive(true);
        }
        else
        {
            PlayerCanWalk(false);
            arrowRefactory.SetActive(false);
        }
    }

    public void ViewEpiMensage()
    {
        PlayerCanWalk(false);
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

    public void ViewEpiEmptyMensage()
    {
        PlayerCanWalk(false);
        epiImageEmpty.SetActive(true);
    }

    public void DeactiveEpiEmptyMensage()
    {
        Invoke("ActiveWalkPlayer", 0.1f);
        gameManager.ResetMissionText();
        gameManager.SetMissionReturnJob();
        gameManager.numberQuestResolve++;
        epiImageEmpty.SetActive(false);
        ViewArrowJob();
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

    public void InitializeJob2()
    {
        managerJob2.EnterNewBox();
    }

    public void InvokeNpcChico()
    {
        NpcChico.SetActive(true);
    }

    public void AnimWokTokEnd()
    {
        WokTok.GetComponent<AudioSource>().Play();
        WokTok.GetComponent<Animator>().SetBool("ActiveWalk", true);
        DialogueWokTok_3.SetActive(true);
        Invoke("ResetAnimWokTok", 0.2f);
        Invoke("ResetDialogueWokTokEnd", 8f);
    }
    void ResetDialogueWokTokEnd()
    {
        DialogueWokTok_3.SetActive(false);
        SelectQuest(8);
    }

    public void DialogueWokTokPedro()
    {
        WokTok.GetComponent<AudioSource>().Play();
        WokTok.GetComponent<Animator>().SetBool("ActiveWalk", true);
        DialogueWokTok_4.SetActive(true);
        Invoke("ResetAnimWokTok", 0.2f);
        Invoke("ResetDialogueWokTokPedro", 8f);
    }
    void ResetDialogueWokTokPedro()
    {
        DialogueWokTok_4.SetActive(false);
        InitializeJob();
    }


    public void AnimWokTok()
    {
        WokTok.GetComponent<AudioSource>().Play();
        WokTok.GetComponent<Animator>().SetBool("ActiveWalk", true);
        if(managerJob.gameObject.activeSelf)
            DialogueWokTok_1.SetActive(true);
        else if(managerJob2.gameObject.activeSelf)
            DialogueWokTok_2.SetActive(true);
        Invoke("ResetAnimWokTok", 0.2f);
        Invoke("ResetDialogueWokTok", 8f);
    }
    void ResetAnimWokTok()
    {
        WokTok.GetComponent<Animator>().SetBool("ActiveWalk", false);
    }
    void ResetDialogueWokTok()
    {        
        if (managerJob.gameObject.activeSelf)
        {
            DialogueWokTok_1.SetActive(false);
            InitializeJob();
        }
        else
        {
            DialogueWokTok_2.SetActive(false);
            SelectQuest(7);
        }
    }

    public void SetEnterRefactory(bool p_enter)
    {
        _enterRefactory = p_enter;
    }

    public bool GetEnterRefactory()
    {
        return _enterRefactory;
    }

    public void FadeIn()
    {
        fade.gameObject.SetActive(true);
        _fadeIn = true;
    }

    public void FadeOut()
    {
        textFade.SetActive(false);
        _fadeOut = true;
    }
}
