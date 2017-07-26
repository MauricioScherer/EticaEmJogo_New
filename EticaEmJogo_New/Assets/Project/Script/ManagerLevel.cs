using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerLevel : MonoBehaviour
{
    private int _numberQuestResolve;
    private int _numberPag;
    private bool _fadeIn;
    private bool _fadeOut;
    private bool _fadeMusic;
    private Color _colorFade;
    
    public GameManager gameManager;
    public GameObject busFinalLevel;
    public GameObject canvasInstruction;
    public GameObject painel;
    public GameObject alertFinalLevel;    
    public GameObject[] instruction;

    public Image fade;
    public GameObject feedback;
    public GameObject buttonBackPag;
    public GameObject buttonNextPag;
    public GameObject buttonContinue;
    public GameObject[] pag;
    public GameObject[] pagCurrent;

    void Start()
    {
        if(canvasInstruction)
        {
            painel.SetActive(true);
            instruction[0].SetActive(true);
            Time.timeScale = 0;
            PlayerNoWalk();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("2"))
            SceneManager.LoadScene("Scene_02");

        if (_fadeIn)
        {
            fade.color = _colorFade;            
            _colorFade.a += 0.7f * Time.deltaTime;            

            if (_colorFade.a >= 1)
            {
                Invoke("FadeOut", 1f);
                _fadeIn = false;
            }
        }
        if (_fadeOut)
        {
            fade.color = _colorFade;
            _colorFade.a -= 0.7f * Time.deltaTime;
            
            if (_colorFade.a <= 0)
            {
                fade.gameObject.SetActive(false);
                Time.timeScale = 0;
                _fadeOut = false;
                if (gameManager.music.volume > 0)
                {
                    gameManager.music.volume = 0;
                    _fadeMusic = false;
                }
            }
        }

        if(_fadeMusic)
            gameManager.music.volume -= 0.12f * Time.deltaTime;
    }

    public void SetEvent(int p_numberQuestCurrent)
    {
        _numberQuestResolve = p_numberQuestCurrent;
        if (_numberQuestResolve == 0)
        {
            gameManager.SelectMensagePhone(_numberQuestResolve, 13);
        }
        else if (_numberQuestResolve == 1)
        {
            gameManager.SelectMensagePhone(_numberQuestResolve, 8);
        }
        else if (_numberQuestResolve == 2)
        {
            Invoke("viewAlertFinalLevel", 6);
        }
    }

    public int GetNumberQuestResolve()
    {
        return _numberQuestResolve;
    }

    public void SelectEventGameManager()
    {
        gameManager.player.CanWalk(false);
        gameManager.SelectQuest(2);
    }

    void viewAlertFinalLevel()
    {
        if(alertFinalLevel)
            alertFinalLevel.SetActive(true);
        if(busFinalLevel)
            busFinalLevel.SetActive(true);
        gameManager.SetMissionText();
        PagDefine(gameManager.GetScore());
        Invoke("ResetAlert", 5);
    }

    void ResetAlert()
    {
        if(alertFinalLevel)
            alertFinalLevel.SetActive(false);
    }

    public void NewInstruction()
    {
        if (painel)
            painel.SetActive(true);
        instruction[1].SetActive(true);
        Time.timeScale = 0;
        PlayerNoWalk();
    }

    public void ReturnToGame()
    {
        for(int i = 0; i < instruction.Length; i++)
        {
            instruction[i].SetActive(false);
        }
        if(painel)
            painel.SetActive(false);
        Time.timeScale = 1;
        Invoke("PlayerCanWalk", 0.5f);
    }

    void PlayerNoWalk()
    {
        gameManager.player.CanWalk(false);
    }

    void PlayerCanWalk()
    {
        gameManager.player.SetValues();
    }

    public bool ResolveTotalQuests()
    {
        if (_numberQuestResolve == 2)
            return true;
        else
            return false;
    }

    public void ViewFeedback()
    {        
        feedback.SetActive(true);
    }

    void PagDefine(float p_points)
    {
        if (p_points >= 12)
        {
            pagCurrent = new GameObject[1] { pag[0] };            
            if (buttonNextPag.activeSelf)
                buttonNextPag.SetActive(false);
            if (buttonBackPag.activeSelf)
                buttonBackPag.SetActive(false);
            if (!buttonContinue.activeSelf)
                buttonContinue.SetActive(true);
        }
        else if(p_points >= 6)
            pagCurrent = new GameObject[2] { pag[1], pag[2] };
        else
            pagCurrent = new GameObject[2] { pag[3], pag[4] };

        pagCurrent[0].SetActive(true);
    }

    public void NextPag()
    {
        if(_numberPag < pagCurrent.Length - 1)
        {
            for (int i = 0; i < pagCurrent.Length; i++)
            {
                if(pagCurrent[i].activeSelf)
                {
                    pagCurrent[i].SetActive(false);
                    pagCurrent[i + 1].SetActive(true);
                    if(i == 0)
                    {
                        buttonBackPag.SetActive(true);
                    }
                    if(i + 1 == pagCurrent.Length - 1)
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
                    if(buttonContinue.activeSelf)
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
            if(tempArray[i] == PlayerPrefs.GetString("cpfSelect"))
            {
                tempPoint[i] = (int)gameManager.GetScore();
                PlayerPrefsUtility.SetIntArray("pointsArray", tempPoint);
                break;
            }
        }
        SceneManager.LoadScene("Scene_anim_entermarket");
    }

    public void FadeIn()
    {
        fade.gameObject.SetActive(true);
        _fadeIn = true;
        _fadeMusic = true;
    }

    public void FadeOut()
    {
        ViewFeedback();
        _fadeOut = true;
    }
}
