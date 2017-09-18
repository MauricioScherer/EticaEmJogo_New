﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class ManagerLevel4 : MonoBehaviour
{
    private int _numberPag;
    private bool _fadeIn;
    private bool _fadeOut;
    private bool _viewQuest1;
    private bool _viewQuest3;
    private Color _colorFade;

    public bool selectNpcAna;
    public GameManager gameManager;
    public GameObject arrowJob;
    public GameObject arrowXerox;
    public GameObject canvasJob;
    public GameObject canvasJob2;
    public GameObject[] objDeactive;
    public Image fade;
    public MotionBlur motionBlur;
    public VignetteAndChromaticAberration vignette;

    public GameObject placarFinalLevel;
    public GameObject particleFinalLevel;
    public GameObject particleFinalLevel2;
    public GameObject particleFinalLevel3;
    public GameObject[] medalForPoints;
    public GameObject[] exclamationAvatar;
    public Transform posDialogueNpc;

    public GameObject feedback;
    public GameObject buttonBackPag;
    public GameObject buttonNextPag;
    public GameObject buttonContinue;
    public GameObject[] pag;
    public GameObject[] pagCurrent;

    void Start ()
    {
        if (Time.deltaTime < 1)
            Time.timeScale = 1;
        if (gameManager.player.GetCanWalk())
        {
            PlayerCanWalk(false);
        }
    }
	
	void Update ()
    {
        if (_fadeIn)
        {
            fade.color = _colorFade;
            _colorFade.a += 0.6f * Time.deltaTime;

            if (_colorFade.a >= 1)
            {
                if (gameManager.numberQuestResolve == 1)
                {
                    ViewCanvasJob();
                    Deactiveobj(0, false);
                    Deactiveobj(1, false);
                    Deactiveobj(2, true);
                    Invoke("FadeOut", 0.5f);
                }
                else if(gameManager.numberQuestResolve == 3)
                {
                    ViewCanvasJob2();
                    Deactiveobj(2, false);
                    Invoke("FadeOut", 0.5f);
                }
                else if (gameManager.numberQuestResolve == 5)
                {
                    ViewFeedback();
                    Invoke("FadeOut", 0.5f);
                }
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
                _fadeOut = false;
            }
        }

        if(gameManager.phone.activeSelf)
        {
            gameManager.phone.SetActive(false);
        }
    }

    public void FadeIn()
    {
        fade.gameObject.SetActive(true);
        _fadeIn = true;
    }

    public void FadeOut()
    {
        _fadeOut = true;
    }

    public void ActiveExclamation(int p_number)
    {
        if (exclamationAvatar[p_number].activeSelf)
            exclamationAvatar[p_number].SetActive(false);
        else
            exclamationAvatar[p_number].SetActive(true);
    }

    public void ViewQuest(int p_numQuest)
    {
        if(!_viewQuest1)
        {
            canvasJob.SetActive(false);
            ViewArrowXerox();
            gameManager.SelectQuest(p_numQuest);
            _viewQuest1 = true;
        }
        else if(!_viewQuest3)
        {
            canvasJob2.SetActive(false);
            gameManager.SelectQuest(p_numQuest);
            _viewQuest3 = true;
        }
    }

    public void FinalizeQuest1()
    {
        //Invoke("ViewCanvasJob", 3f);
    }

    public void Deactiveobj(int p_num, bool p_status)
    {
        objDeactive[p_num].SetActive(p_status);
    }

    public void InvokeActiveEffectCam()
    {
        Invoke("ActiveEffectCam", 6f);
        Invoke("ViewLastQuest", 10f);
    }

    public void ActiveEffectCam()
    {
        vignette.enabled = true;
        motionBlur.enabled = true;
        gameManager.music.pitch = 0.5f;
        Time.timeScale = 0.5f;        
    }

    public void DesativeEffectCam()
    {
        vignette.enabled = false;
        motionBlur.enabled = false;
        PlayerCanWalk(false);
        gameManager.music.Stop();
        Time.timeScale = 1f;
    }

    void ViewLastQuest()
    {
        gameManager.SelectQuest(12);
    }

    public void ViewArrowJob()
    {
        if (!arrowJob.activeSelf)
        {
            arrowJob.SetActive(true);
        }
        else
        {
            arrowJob.SetActive(false);
        }
    }

    public void ViewArrowXerox()
    {
        if (!arrowXerox.activeSelf)
        {
            arrowXerox.SetActive(true);
        }
        else
        {
            arrowXerox.SetActive(false);
        }
    }

    public void ViewCanvasJob()
    {
        if (!canvasJob.activeSelf)
        {
            canvasJob.SetActive(true);
        }
        else
        {
            canvasJob.SetActive(false);
        }
    }

    public void ViewCanvasJob2()
    {
        if (!canvasJob2.activeSelf)
        {
            canvasJob2.SetActive(true);
        }
        else
        {
            canvasJob2.SetActive(false);
        }
    }

    public void ViewPlacarFinalLevel(bool p_activate)
    {
        gameManager.player.CanWalk(false);
        placarFinalLevel.SetActive(p_activate);
        if (p_activate)
        {
            if (gameManager.GetScore() >= 12)
            {
                particleFinalLevel.SetActive(p_activate);
                medalForPoints[0].SetActive(true);
            }
            else if (gameManager.GetScore() >= 6)
            {
                particleFinalLevel2.SetActive(p_activate);
                medalForPoints[1].SetActive(true);
            }
            else
            {
                particleFinalLevel3.SetActive(p_activate);
                medalForPoints[2].SetActive(true);
            }
        }
        else
        {
            if (particleFinalLevel.activeSelf)
                particleFinalLevel.SetActive(false);
            if (particleFinalLevel2.activeSelf)
                particleFinalLevel2.SetActive(false);
            if (particleFinalLevel3.activeSelf)
                particleFinalLevel3.SetActive(false);
            medalForPoints[0].SetActive(false);
            medalForPoints[1].SetActive(false);
            medalForPoints[2].SetActive(false);
        }
    }

    public void PlayerCanWalk(bool p_canwalk)
    {
        gameManager.player.CanWalk(p_canwalk);
    }

    public void ViewFeedback()
    {
        feedback.SetActive(true);
        gameManager.ActivateAndDeactivateHud();
        PagDefine(gameManager.GetScore());
    }
    void PagDefine(float p_points)
    {
        if (p_points >= 12)
            pagCurrent = new GameObject[1] { pag[0] };
        else if (p_points >= 6)
            pagCurrent = new GameObject[1] { pag[1] };
        else
            pagCurrent = new GameObject[1] { pag[2] };

        if (buttonNextPag.activeSelf)
            buttonNextPag.SetActive(false);
        if (buttonBackPag.activeSelf)
            buttonBackPag.SetActive(false);
        if (!buttonContinue.activeSelf)
            buttonContinue.SetActive(true);

        pagCurrent[0].SetActive(true);
    }
    public void NextPag()
    {
        if (_numberPag < pagCurrent.Length - 1)
        {
            for (int i = 0; i < pagCurrent.Length; i++)
            {
                if (pagCurrent[i].activeSelf)
                {
                    pagCurrent[i].SetActive(false);
                    pagCurrent[i + 1].SetActive(true);
                    if (i == 0)
                    {
                        buttonBackPag.SetActive(true);
                    }
                    if (i + 1 == pagCurrent.Length - 1)
                    {
                        buttonNextPag.SetActive(false);
                        buttonContinue.SetActive(true);
                    }
                    break;
                }
            }
            _numberPag++;
        }
    }
    public void BackPag()
    {
        if (_numberPag > 0)
        {
            for (int i = 0; i < pagCurrent.Length; i++)
            {
                if (pagCurrent[i].activeSelf)
                {
                    pagCurrent[i].SetActive(false);
                    pagCurrent[i - 1].SetActive(true);
                    if (i == 1)
                    {
                        buttonBackPag.SetActive(false);
                    }
                    if (buttonContinue.activeSelf)
                    {
                        buttonContinue.SetActive(false);
                        buttonNextPag.SetActive(true);
                    }
                    break;
                }
            }
            _numberPag--;
        }
    }
    public void ButtonContinue()
    {
        string[] tempArray = new string[20];
        tempArray = PlayerPrefsUtility.GetStringArray("cpfArray");

        int[] tempPoint = new int[20];
        tempPoint = PlayerPrefsUtility.GetIntArray("pointsArray");
        for (int i = 0; i < tempArray.Length; i++)
        {
            if (tempArray[i] == PlayerPrefs.GetString("cpfSelect"))
            {
                tempPoint[i] += (int)gameManager.GetScore();
                PlayerPrefsUtility.SetIntArray("pointsArray", tempPoint);
                break;
            }
        }
        SceneManager.LoadScene("Menu");
    }
}
