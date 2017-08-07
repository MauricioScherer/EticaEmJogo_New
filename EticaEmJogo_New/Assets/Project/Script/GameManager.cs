﻿using System.Collections;
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
    public ManagerLevel3 managerLevel3;
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
    public Text missionCurrent;
    public GameObject missionAlert;
    public Text missionDescription;

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

        if (_numberScene == 3)
            player.CanWalk(false);

        _numberPointsForLevel = 0;
    }
	
	void Update ()
    {

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

        if (_stayQuest)
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
                if(managerLevel2.numClientFinalize == 0 && numberQuestResolve > 3)
                    managerLevel2.finalQuestResolve = true;
                else
                    player.SetValues();
            }
            else if(_numberQuestStay != 6 && _numberQuestStay != 7 && _numberQuestStay != 8)
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
                missionAlert.SetActive(true);
                missionDescription.text = "Procure pela carteira perdida";
            }
            else if (numberQuestResolve == 1)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Encontro na praça";
                missionAlert.SetActive(true);
                missionDescription.text = "Encontre seus amigos na praça";
            }
            else if (numberQuestResolve == 3)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Chegar ao ponto de ônibus";
                missionAlert.SetActive(true);
                missionDescription.text = "Pegar o ônibus para iniciar o seu primeiro dia de trabalho no mercado “Tudo Tem”";
            }
        }
        else if(GetNumberScene() == 3)
        {
            if (numberQuestResolve == 1)
            {
                missionCurrent.text = "Falar com Carla";
                missionAlert.SetActive(true);
                missionDescription.text = "Volte a falar com a Carla";
            }
            else if (numberQuestResolve == 2)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Falar com Supervisor";
                missionAlert.SetActive(true);
                missionDescription.text = "Conheça seu supervisor na sala ao lado, ele irá passar mais informações";
            }
            else if (numberQuestResolve == 3)
            {
                if (missionCurrent.text == "")
                    missionCurrent.text = "Ir ao posto de trabalho";
                missionAlert.SetActive(true);
                missionDescription.text = "Vá até seu posto de trabalho pra começar seu trabalho";
            }
        }
        else if(GetNumberScene() == 4)
        {
            if (numberQuestResolve == 0 || numberQuestResolve == 3)
            {
                missionCurrent.text = "Pegar EPI's";
                missionAlert.SetActive(true);
                missionDescription.text = "Vá até seu armario e pegue seus equipamentos de proteção individual";
            }
            else if (numberQuestResolve == 1)
            {
                missionCurrent.text = "Falar com Pedro";
                missionAlert.SetActive(true);
                missionDescription.text = "Fale com seu colega pedro, ele ira ajudar nas suas novas tarefas";
            }
            else if (numberQuestResolve == 2)
            {
                missionCurrent.text = "Tirar EPI";
                missionAlert.SetActive(true);
                missionDescription.text = "Vá até o seu armário, deixe seu EPI para você ir ao refeitório almoçar";
            }
        }

        if(missionAlert.activeSelf)
        {
            Invoke("DeactveMissionAlert", 4f);
        }
    }

    public void viewMissionAlert()
    {
        Invoke("SetMissionTextCaseSpecial", 1f);
    }

    public void SetMissionFinalLevelMarket()
    {
        if (missionCurrent.text == "")
            missionCurrent.text = "Ir para Estoque";
        missionAlert.SetActive(true);
        missionDescription.text = "Você teve um ótimo desempenho no trabalho, você será promovido! ir até o estoque";
        player.CanWalk(true);

        if (missionAlert.activeSelf)
        {
            Invoke("DeactveMissionAlert", 4f);
        }
    }

    public void SetMissionRefectory()
    {
        missionCurrent.text = "Ir para Refeitório";
        missionAlert.SetActive(true);
        missionDescription.text = "Vá até o refeitório para o horário de almoço";
        player.CanWalk(true);

        if (missionAlert.activeSelf)
        {
            Invoke("DeactveMissionAlert", 4f);
        }
    }

    void SetMissionTextCaseSpecial()
    {
        if (numberQuestResolve == 1)
        {
            if (missionCurrent.text == "")
                missionCurrent.text = "Mural de avisos";
            missionAlert.SetActive(true);
            missionDescription.text = "Ler sobre os assuntos que a Carla mensionou no mural de avisos";
        }

        if (missionAlert.activeSelf)
        {
            Invoke("DeactveMissionAlert", 4f);
        }
    }

    public void SetMissionReturnJob()
    {
        missionCurrent.text = "Voltar ao trabalho";
        missionAlert.SetActive(true);
        missionDescription.text = "Retorne para o seu local de trabalho para continuar suas tarefas";
        player.CanWalk(true);

        if (missionAlert.activeSelf)
        {
            Invoke("DeactveMissionAlert", 4f);
        }
    }

    void DeactveMissionAlert()
    {
        missionAlert.SetActive(false);
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