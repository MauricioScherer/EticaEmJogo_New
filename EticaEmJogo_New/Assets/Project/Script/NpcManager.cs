using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcManager : MonoBehaviour
{
    public enum states
    {
        IDLE_STATE,
        LOSE_STATE,
        MOVE_STATE
    }
    public states startState;

    public enum quest
    {
        QUEST_NULL,
        QUEST_1,
        QUEST_2,
        QUEST_3,
        QUEST_4,
        QUEST_5,
        QUEST_6,
        QUEST_7,
        QUEST_8,
        QUEST_9,
        QUEST_10,
        QUEST_11,
        QUEST_12
    }
    public quest questStay;

    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _waveActive;
    private bool _randomSelectPath;
    public bool questResolved;
    private int _sort;
    private int _stateSelect;
    private int _stateQuest;

    public GameObject exclamation;
    public GameObject ballonWallet;
    public GameManager gameManager;
    public Transform[] path;

    void Awake ()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _stateSelect = (int)startState;
        _stateQuest = (int)questStay;
        if (_stateSelect == 2)
        {
            SelectPath();
        }
        else if(_stateSelect == 1)
        {
            SetAnimLose();
            _navMeshAgent.enabled = false;
        }
        else
        {
            _navMeshAgent.enabled = false;
        }
     
    }

	void Update ()
    {
        if(_stateSelect == 2)
        {
            if (_navMeshAgent.remainingDistance > 0.05f)
            {
                _anim.SetFloat("MoveSpeed", _navMeshAgent.speed);
            }
            else
            {
                _anim.SetFloat("MoveSpeed", 0);
                if (!_randomSelectPath)
                {
                    Invoke("SelectPath", 5f);
                    _randomSelectPath = true;
                }
            }
        }
	}

    void OnMouseEnter()
    {
        if(!questResolved && !_waveActive && _stateSelect == 0)
        {
            _waveActive = true;
            _anim.SetBool("Wave", _waveActive);
            exclamation.SetActive(true);
            Invoke("SetWaveActivated", 1f);
        }
    }

    void OnMouseExit()
    {
        _waveActive = false;
        _anim.SetBool("Wave", _waveActive);
        exclamation.SetActive(false);
    }

    void SetWaveActivated()
    {
        _waveActive = false;
        _anim.SetBool("Wave", _waveActive);
    }

    void SetAnimLose()
    {
        _anim.SetBool("Lose2", true);
    }

    public void SetAnimVictory()
    {
        if (ballonWallet.activeSelf)
            ballonWallet.SetActive(false);
        _anim.SetBool("Lose2", false);
        _anim.SetBool("Victory", true);
        Invoke("SetStandardAnim", 0.5f);
    }

    void SetStandardAnim()
    {
        if(_anim.GetBool("Wave"))
            _anim.SetBool("Wave", false);
        if (_anim.GetBool("Lose1"))
            _anim.SetBool("Lose1", false);
        if (_anim.GetBool("Lose2"))
            _anim.SetBool("Lose2", false);
        if (_anim.GetBool("Victory"))
            _anim.SetBool("Victory", false);
        if (_anim.GetBool("Conversation"))
            _anim.SetBool("Conversation", false);
        if (_anim.GetBool("NoGesture"))
            _anim.SetBool("NoGesture", false);
        if (_anim.GetBool("Pickup"))
            _anim.SetBool("Pickup", false);
        if (_anim.GetBool("Shrug"))
            _anim.SetBool("Shrug", false);
        if (_anim.GetBool("YesGesture"))
            _anim.SetBool("YesGesture", false);
    }

    void SelectPath()
    {
        _sort = Random.Range(0, 3);

        _navMeshAgent.destination = path[_sort].position;
        _navMeshAgent.Resume();
        _randomSelectPath = false;
    }

    public int GetQuestStay()
    {
        return _stateQuest;
    }
}
