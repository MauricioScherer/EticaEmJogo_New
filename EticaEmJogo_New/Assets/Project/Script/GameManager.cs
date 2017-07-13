using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float _Score;
    private bool _stayQuest;
    private int _numberQuestStay;
    private int _numberPointsForLevel;
    private int _numberMensagePhone;
    private int _numberScene;
    public bool _stayTriggerFade;
    private GameObject _avatarQuestCurrent;

    public int numberQuestResolve;
    public ManagerLevel managerLevel;
    public ManagerLevel2 managerLevel2;
    public GameObject[] quest;
    public GameObject canvasGameManger;
    public GameObject help;
    public GameObject score;
    public GameObject phone;
    public GameObject sprMusicActivate;
    public GameObject painelPause;
    public GameObject painelMission;
    public GameObject[] poolAvatar;    
    public MovePlayer player;
    public GameObject[] poolAvatarQuest;
    public CelularManager celularManager;
    public Image scoreBar;
    public AudioSource music;
    public AudioSource effect;
    public AudioClip[] clipEffect;
    public CameraPosition camPosition;
    public Animator Fade;
    public Text missionCurrent;

    void Awake ()
    {
        numberQuestResolve = 0;
        _numberScene = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.HasKey("avatarSelect"))
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

        if (_numberScene == 2)
            player.CanWalk(false);

        _numberPointsForLevel = 0;
    }
	
	void Update ()
    {

    }

    public void StartFade()
    {
        Fade.SetBool("FadeIn", true);
        Invoke("ResetFade", 1);
    }

    void ResetFade()
    {
        Fade.SetBool("FadeIn", false);
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
            Invoke("InvokeSetValue", 0.3f);            
        }
    }

    void InvokeSetValue()
    {
        player.SetValues();
    }

    public void StayQuest()
    {
        _stayQuest = !_stayQuest;        
    }

    public void CheckQuest(int p_score)
    {
        _Score += p_score;
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
        else
        {
            player.SetValues();
        }         
    }

    public void DeactiveHudAndPause()
    {
        Time.timeScale = 0;
        ActivateAndDeactivateHud();
        if (!_stayQuest)
            player.CanWalk(true);
    }

    public void ActivateAndDeactivateHud()
    {
        if(score.activeSelf)
        {
            score.SetActive(false);
            help.SetActive(false);
            phone.SetActive(false);
            painelMission.SetActive(false);
        }
        else
        {
            score.SetActive(true);
            help.SetActive(true);
            phone.SetActive(true);
            painelMission.SetActive(true);
        }        
    }
    
    float ScoreCalculation()
    {
        quest[_numberQuestStay].SetActive(false);
        _avatarQuestCurrent.SetActive(false);
        if(_numberQuestStay != 4)
        {
            if(managerLevel2)
            {
                if(managerLevel2.numClientFinalize == 4)
                    managerLevel2.finalQuestResolve = true;
                else
                    player.SetValues();
            }
            else
            {
                player.SetValues();
            }
        }
        else
        {
            managerLevel2.ViewAlertClientIn();
        }

        if (managerLevel)
            managerLevel.SetEvent(numberQuestResolve);

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

    public void PlayEffect(int p_clip)
    {
        effect.clip = clipEffect[p_clip];
        effect.Play();
    }

    public bool isPlayEffect()
    {
        return effect.isPlaying;
    }

    public void SetMissionText()
    {
        if (GetNumberScene() == 1)
        {
            if (numberQuestResolve == 0)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "A carteira perdida";
            }
            else if (numberQuestResolve == 1)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Encontro na praça";
            }
            else if (numberQuestResolve == 3)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Hora do ônibus";
            }
        }
        else if(GetNumberScene() == 2)
        {
            if (numberQuestResolve == 0)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Mural de avisos";
            }
            else if (numberQuestResolve == 1)
            {
                missionCurrent.text = "Falar com Carla";
            }
            else if (numberQuestResolve == 2)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Falar com Supervisor";
            }
            else if (numberQuestResolve == 3)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Ir ao posto de trabalho";
            }
        }
    }

    public void ResetMissionText()
    {
        missionCurrent.text = "";
    }

    public int GetNumberScene()
    {
        return _numberScene;
    }

    public bool GetStayTriggerFade()
    {
        return _stayTriggerFade;
    }

    public void SetStayTriggerFade(bool p_stay)
    {
        _stayTriggerFade = p_stay;
    }

    public void ViewCanvasGameManager()
    {
        if (!canvasGameManger.activeSelf)
            canvasGameManger.SetActive(true);
        else
            canvasGameManger.SetActive(false);
    }

    public void MusicActivate()
    {
        if(music.isPlaying)
        {
            sprMusicActivate.SetActive(false);
            music.Pause();
        }
        else
        {
            sprMusicActivate.SetActive(true);
            music.Play();
        }
    }
}