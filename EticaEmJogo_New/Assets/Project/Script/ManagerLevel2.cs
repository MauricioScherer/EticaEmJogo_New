using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerLevel2 : MonoBehaviour
{
    public int _numberQuestResolve;
    private int _numberPag;

    private bool _fadeIn;
    private bool _fadeOut;
    private bool _fadeMusic;
    private Color _colorFade;

    public bool quest1Resolve;
    public bool finalQuestResolve;
    public int numClientFinalize;
    public GameManager gameManager;
    public GameObject canvasLevel;
    public GameObject canvasMarket;
    public GameObject arrowCaixa;
    public GameObject point_PS_Pos1;
    public CelularManager celularManager;
    public GameObject painel;
    public GameObject clientIn;
    public NpcController npcController;
    public NpcControllerIa npcControlerIA;
    public NpcDialogue1 npcDialogue;
    public Image fade;
    public GameObject arrowEstoque;

    public GameObject feedback;
    public GameObject buttonBackPag;
    public GameObject buttonNextPag;
    public GameObject buttonContinue;
    public GameObject[] pag;
    public GameObject[] pagCurrent;

    void Awake()
    {
        if(Time.deltaTime < 1)
            Time.timeScale = 1;
        gameManager.music.Play();
        Invoke("EventCelularQuest1", 5);
    }

    void Update()
    {
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

        if (_fadeMusic)
            gameManager.music.volume -= 0.12f * Time.deltaTime;
    }

    public void FadeOut()
    {
        ViewFeedback();
        _fadeOut = true;
    }

    public void FadeIn()
    {
        fade.gameObject.SetActive(true);
        _fadeIn = true;
        _fadeMusic = true;
    }

    public void ViewArrowEstoque()
    {
        if(!arrowEstoque.activeSelf)
            arrowEstoque.SetActive(true);
        else
            arrowEstoque.SetActive(false);
    }

    public int GetNumberQuestResolve()
    {
        return _numberQuestResolve;
    }
    
    public void viewFinalLevel()
    {
        PagDefine(gameManager.GetScore());
        ViewArrowEstoque();
    }

    void EventCelularQuest1()
    {
        celularManager.SetMensage(2);
    }

    public void ReturnToGame()
    {
        if(painel)
            painel.SetActive(false);
        if(canvasLevel)
        {
            ViewCanvasMural(false);
            if (_numberQuestResolve == 0)
            {
                _numberQuestResolve = 1;
                gameManager.SetMissionText();
            }
        }

        gameManager.ActivateAndDeactivateHud();
        Time.timeScale = 1;
        Invoke("PlayerCanWalk", 1f);
    }

    void PlayerNoWalk()
    {
        gameManager.player.CanWalk(false);
    }

    void PlayerCanWalk()
    {
        gameManager.player.SetValues();
    }

    public void ViewCanvasMural(bool p_view)
    {
        canvasLevel.SetActive(p_view);
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
        else if (p_points >= 6)
            pagCurrent = new GameObject[2] { pag[1], pag[2] };
        else
            pagCurrent = new GameObject[3] { pag[3], pag[4], pag[5] };

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
        SceneManager.LoadScene("Scene_03");
    }

    public int GetNumberQuest()
    {
        return _numberQuestResolve;
    }

    public void SetNumberQuest(int p_number)
    {
        _numberQuestResolve = p_number;
    }

    public void ViewArrow(bool p_active)
    {
        arrowCaixa.SetActive(p_active);
        point_PS_Pos1.SetActive(p_active);
    }

    public void ViewAlertClientIn()
    {
        if(!clientIn.activeSelf)
        {
            clientIn.SetActive(true);
            Invoke("ViewAlertClientIn", 2f);
        }
        else
        {
            npcController.InvokeNewCliente();
            npcControlerIA.InvokeNewCliente();
            npcDialogue.ActiveBallonStand();
            clientIn.SetActive(false);
        }
    }

    public void ViewCanvasMarket()
    {
        gameManager.ViewCanvasGameManager();
        if (!canvasMarket.activeSelf)
            canvasMarket.SetActive(true);
        else
            canvasMarket.SetActive(false);
    }
}
