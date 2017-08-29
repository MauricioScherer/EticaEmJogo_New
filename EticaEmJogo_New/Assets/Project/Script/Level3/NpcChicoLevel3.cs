using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcChicoLevel3 : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _SelectPath;
    private int _numPath;

    public ManagerLevel3 managerLevel;
    public GameObject npcCurrent;
    public Transform[] path;
    public GameObject ballonDialoge;
    public GameObject ballonDialoge2;

    void Awake()
    {
        _anim = npcCurrent.GetComponent<Animator>();
        _navMeshAgent = npcCurrent.GetComponent<NavMeshAgent>();

        _navMeshAgent.destination = path[_numPath].position;
        //_navMeshAgent.Resume();
        _navMeshAgent.isStopped = false;
    }

    void Update ()
    {
        if (_navMeshAgent.remainingDistance > 0.05f)
        {
            _anim.SetFloat("MoveSpeed", _navMeshAgent.speed);
        }
        else
        {
            _anim.SetFloat("MoveSpeed", 0);
            if (!_SelectPath)
            {
                if (_numPath == 0)
                {
                    _numPath++;
                    _anim.SetBool("ButtonPress", true);
                    Invoke("ResetAnim", 0.5f);
                    Invoke("SelectNewPath", 3f);
                }
                else if (_numPath == 1)
                {
                    _numPath++;
                    Invoke("InvokeQuest", 6f);
                    ballonDialoge.SetActive(true);
                }
                else if (_numPath == 2)
                {
                    gameObject.SetActive(false);
                }
                _SelectPath = true;
            }
        }
    }

    void InvokeQuest()
    {
        managerLevel.SelectQuest(6);
        ballonDialoge.SetActive(false);
    }

    public void SelectNewPath()
    {
        _navMeshAgent.destination = path[_numPath].position;
        //_navMeshAgent.Resume();
        _navMeshAgent.isStopped = false;
        _SelectPath = false;
        if(ballonDialoge2.activeSelf)
        {
            managerLevel.InitializeJob();
            ballonDialoge2.SetActive(false);
        }
    }

    void ResetAnim()
    {
        _anim.SetBool("ButtonPress", false);
    }

    public void FinalizeQuestChico()
    {
        ballonDialoge2.SetActive(true);
        Invoke("SelectNewPath", 3f);
    }
}
