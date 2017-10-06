using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerLevel3 : MonoBehaviour
{
    private bool _enterRefactory;
    private bool _fadeIn;
    private bool _fadeOut;
    //private bool _fadeMusic;
    private Color _colorFade;
    private int _numberPag;

    public bool finalizeIntroDialogue;
    public bool getEpi;
    public bool dialogueNpcPedro;
    public GameManager gameManager;
    public NpcManager npcManager1;
    public QuestOptionsManager quest7;
    public QuestOptionsManager quest8;
    public QuestOptionsManager quest9;
    public GameObject arrowLockers;
    public GameObject arrowJog;
    public GameObject arrowRefactory;
    public GameObject arrowPedro;
    public GameObject epiImage;
    public GameObject epiImageEmpty;
    public GameObject canvasJob1;
    public GameObject canvasJob2;
    public ManagerJodLevel3 managerJob;
    public ManagerJod2Level3 managerJob2;
    public GameObject canvasMural;
    public GameObject NpcChico;
    public GameObject NpcSandro;
    public GameObject WokTok;
    public GameObject DialogueWokTok_1;
    public GameObject DialogueWokTok_2;
    public GameObject DialogueWokTok_3;
    public GameObject DialogueWokTok_4;
    public GameObject DialogueWokTok_5;
    public Image fade;
    public GameObject textFade;
    public GameObject npcCarla;
    public TextMesh dialogueCarla1;
    public GameObject[] objectDeactive;
    public GameObject[] LightJob;
    public GameObject[] exclamationAvatar;
    public GameObject placarFinalLevel;
    public GameObject particleFinalLevel;
    public GameObject particleFinalLevel2;
    public GameObject particleFinalLevel3;
    public GameObject[] medalForPoints;

    public GameObject feedback;
    public GameObject buttonBackPag;
    public GameObject buttonNextPag;
    public GameObject buttonContinue;
    public GameObject[] pag;
    public GameObject[] pagCurrent;

    void Start()
    {
        if (Time.deltaTime < 1)
            Time.timeScale = 1;
        if (gameManager.player.GetCanWalk())
        {
            PlayerCanWalk(false);
        }
        dialogueCarla1.text = "Parabéns, " + PlayerPrefs.GetString("nameSelect") + "!" + "\n Durante seu contrato \n de experiência, você...";
    }

    void Update()
    {
        if (_fadeIn)
        {
            fade.color = _colorFade;
            _colorFade.a += 0.6f * Time.deltaTime;

            if (_colorFade.a >= 1)
            {
                if (gameManager.numberQuestResolve == 2)
                {
                    textFade.SetActive(true);
                    Invoke("FadeOut", 3f);
                }
                else if (gameManager.numberQuestResolve == 6)
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
                if(textFade.activeSelf)
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

    public void ViewArrowPedro()
    {
        if (!arrowPedro.activeSelf)
            arrowPedro.SetActive(true);
        else
            arrowPedro.SetActive(false);
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
        if(quest8.gameObject.activeSelf)
        {
            if(quest8.GetActiveSelectQuest())
            {
                managerJob2.EnterNewBox();
            }
        }
        else if(quest9.gameObject.activeSelf)
        {
            if (quest9.GetActiveSelectQuest())
            {
                managerJob2.EnterNewBox();
            }
        }
        else
        {
            managerJob2.EnterNewBox();
        }
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
    }
    public void ResetDialogueWokTokEnd()
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
    }
    public void ResetDialogueWokTokPedro()
    {
        DialogueWokTok_4.SetActive(false);
        InitializeJob2();
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
    }
    void ResetAnimWokTok()
    {
        WokTok.GetComponent<Animator>().SetBool("ActiveWalk", false);
    }
    public void ResetDialogueWokTok()
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

    public void ViewLastWalkTock()
    {
        WokTok.GetComponent<AudioSource>().Play();
        WokTok.GetComponent<Animator>().SetBool("ActiveWalk", true);
        DialogueWokTok_5.SetActive(true);
        Invoke("ResetAnimWokTok", 0.2f);
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

    //public void FadeMusic()
    //{
    //    _fadeMusic = true;
    //}

    public void FadeOut()
    {
        textFade.SetActive(false);
        _fadeOut = true;
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

    public void DeactiveObjetsPosScene()
    {
        for(int i = 0; i < objectDeactive.Length; i++)
        {
            if(objectDeactive[i].activeSelf)
                objectDeactive[i].SetActive(false);
        }
    }

    public void ActiveLastDialogueNpc()
    {
        npcCarla.SetActive(true);
        DialogueWokTok_5.SetActive(false);
        PlayerCanWalk(true);
    }

    public void DefineLightJob(int p_numLight)
    {
        for(int i = 0; i < LightJob.Length; i++)
        {
            if (i != p_numLight)
                LightJob[i].SetActive(false);
            else
                LightJob[i].SetActive(true);
        }
    }

    //feedback
    public void ViewFeedback()
    {
        WokTok.SetActive(false);
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
                PlayerPrefs.SetInt("pointsSelect", tempPoint[i]);
                PlayerPrefsUtility.SetIntArray("pointsArray", tempPoint);
                break;
            }
        }
        SceneManager.LoadScene("Scene_04");
    }

    public void ActiveExclamation(int p_number)
    {
        if (exclamationAvatar[p_number].activeSelf)
            exclamationAvatar[p_number].SetActive(false);
        else
            exclamationAvatar[p_number].SetActive(true);
    }

    public void ViewCanvasMural(bool p_view)
    {
        canvasMural.SetActive(p_view);
    }

    public void ReturnToGame()
    {
        ViewCanvasMural(false);
        gameManager.ActivateAndDeactivateHud();
        Invoke("PlayerCanWalk", 0.5f);
    }

    void PlayerCanWalk()
    {
        gameManager.player.SetValues();
    }
}
