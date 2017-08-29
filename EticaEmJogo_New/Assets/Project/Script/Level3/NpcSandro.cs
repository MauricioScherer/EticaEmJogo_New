using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcSandro : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _SelectPath;
    private int _numPath;

    public ManagerLevel3 managerLevel;
    public GameObject npcCurrent;
    public Transform[] path;
    public GameObject ballonDialoge;

    void Start ()
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
                    ballonDialoge.SetActive(true);
                }
                else if(_numPath == 1)
                {                    
                    gameObject.SetActive(false);
                }
                _SelectPath = true;
            }
        }
    }

    public void SelectNewPath()
    {
        _navMeshAgent.destination = path[_numPath].position;
        //_navMeshAgent.Resume();
        _navMeshAgent.isStopped = false;
        if (_SelectPath)
            _SelectPath = false;
    }
}
