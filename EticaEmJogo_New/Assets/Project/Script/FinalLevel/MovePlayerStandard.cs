using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayerStandard : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;

    public Transform path;

    void Start ()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        SelectNewPath();
    }

    void Update()
    {
        if (_navMeshAgent.remainingDistance > 0.05f)
        {
            _anim.SetFloat("MoveSpeed", _navMeshAgent.speed);
        }
        else
        {
            _anim.SetFloat("MoveSpeed", 0);
        }
    }

    void SelectNewPath()
    {
        _navMeshAgent.destination = path.position;
        _navMeshAgent.isStopped = false;
    }
}
