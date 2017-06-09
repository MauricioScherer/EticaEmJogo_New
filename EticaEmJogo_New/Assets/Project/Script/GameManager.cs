using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float _Score;
    private bool _stayQuest;
    private int _numberQuestStay;
    private int _numberPointsForLevel;
    private int _numberMensagePhone;
    private GameObject _avatarQuestCurrent;

    public int numberQuestResolve;
    public ManagerLevel managerLevel;
    public GameObject[] quest;
    public GameObject help;
    public GameObject score;
    public GameObject phone;
    public GameObject painelPause;
    public GameObject[] poolAvatar;    
    public MovePlayer player;
    public GameObject[] poolAvatarQuest;
    public CelularManager celularManager;
    public Image scoreBar;
    public AudioSource music;
    public Slider controllerMusic;
    public CameraPosition camPosition;

    public Texture2D cursorTextureStandard;
    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    void Awake ()
    {
        numberQuestResolve = 0;
        Cursor.SetCursor(cursorTextureStandard, hotSpot, cursorMode);
        controllerMusic.value = 0.1f;
        music.volume = controllerMusic.value;
        if(PlayerPrefs.HasKey("avatarSelect"))
        {
            int __tempNumberPool = PlayerPrefs.GetInt("avatarSelect");
            poolAvatar[__tempNumberPool].SetActive(true);
            _avatarQuestCurrent = poolAvatarQuest[__tempNumberPool];
            player = poolAvatar[__tempNumberPool].GetComponent<MovePlayer>();
            camPosition.playerPosition = poolAvatar[__tempNumberPool].transform;
        }
        else
        {
            poolAvatar[0].SetActive(true);
            player = poolAvatar[0].GetComponent<MovePlayer>();
            camPosition.playerPosition = poolAvatar[0].transform;
        }
        _numberPointsForLevel = 0;
    }
	
	void Update ()
    {
        if(painelPause.activeSelf)
        {
            music.volume = controllerMusic.value;
        }
    }

    public void SelectQuest(int p_numQuest)
    {
        if(p_numQuest < quest.Length)
        {     
            if (quest[p_numQuest] != null)
            {
                _numberQuestStay = p_numQuest;
                _numberPointsForLevel += 5;
                celularManager.DeactiveView();
                quest[p_numQuest].SetActive(true);
                _avatarQuestCurrent.SetActive(true);
                StayQuest();
                ActivateAndDeactivateHud();
            }
        }
        else
        {
            player.SetValues();
        }
    }

    public void StayQuest()
    {
        _stayQuest = !_stayQuest;        
    }

    public void CorrectAnswer()
    {
        _Score += 5;
        ActivateAndDeactivateHud();
        StayQuest();
        scoreBar.fillAmount = ScoreCalculation();
    }

    public void RightAnswer()
    {
        _Score += 2;
        ActivateAndDeactivateHud();
        StayQuest();
        scoreBar.fillAmount = ScoreCalculation();
    }

    public void WrongAnswer()
    {
        ActivateAndDeactivateHud();
        StayQuest();
        scoreBar.fillAmount = ScoreCalculation();
    } 
    
    public void PauseSelect()
    {
        Time.timeScale = 0;
        painelPause.SetActive(true);
        ActivateAndDeactivateHud();
        for (int i = 0; i < quest.Length; i++)
        {
            if(quest[i].activeSelf)
            {
                _numberQuestStay = i;
                quest[i].SetActive(false);
                _avatarQuestCurrent.SetActive(false);
                break;
            }
        }
    } 

    public void ReturnPause()
    {
        Time.timeScale = 1;
        painelPause.SetActive(false);
        ActivateAndDeactivateHud();
        if(_stayQuest)
        {
            quest[_numberQuestStay].SetActive(true);
            _avatarQuestCurrent.SetActive(true);
        }            
    }

    void ActivateAndDeactivateHud()
    {
        if(score.activeSelf)
        {
            score.SetActive(false);
            help.SetActive(false);
            phone.SetActive(false);          
        }
        else
        {
            score.SetActive(true);
            help.SetActive(true);
            phone.SetActive(true);
        }        
    }
    
    float ScoreCalculation()
    {
        quest[_numberQuestStay].SetActive(false);
        _avatarQuestCurrent.SetActive(false);
        player.SetValues();
        if (managerLevel)
        {
            managerLevel.SetEvent(numberQuestResolve);
        }
        numberQuestResolve++;
        return _Score / _numberPointsForLevel;
    }

    public void SelectMensagePhone(int p_numberMensage, int p_time)
    {
        _numberMensagePhone = p_numberMensage;
        Invoke("InvokeNewMensage", p_time);
    }

    void InvokeNewMensage()
    {
        celularManager.CleanMensage();
        celularManager.SetMensage(_numberMensagePhone);
    }

    public float GetScore()
    {
        return _Score;
    }
}
