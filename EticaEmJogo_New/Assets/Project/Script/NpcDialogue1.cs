﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcDialogue1 : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _SelectPath;
    public int _numPath;

    public bool isMove;
    public GameManager gameManager;
    public GameObject ballonDialoge;
    public GameObject npcCurrent;
    public Transform[] path;

    void Awake()
    {
        _anim = npcCurrent.GetComponent<Animator>();
        _navMeshAgent = npcCurrent.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(isMove)
        {
            if (_navMeshAgent.remainingDistance > 0.05f)
            {
                _anim.SetFloat("MoveSpeed", _navMeshAgent.speed);
            }
            else
            {
                _anim.SetFloat("MoveSpeed", 0);
                if (_numPath < path.Length - 1)
                {
                    if (!_SelectPath)
                    {
                        if (_numPath == 1)
                        {
                            _anim.SetBool("PickUp", true);
                            Invoke("ResetAnim", 2f);
                        }
                        else
                        {
                            _numPath++;
                            Invoke("SelectNewPath", 0.05f);
                        }                                             
                        _SelectPath = true;
                    }
                }
                else
                {
                    Invoke("SetDance", 2f);
                    Invoke("ResetDance", 4f);
                    Invoke("InvokeQuest", 6f);
                    isMove = false;
                }
            }
        }
    }

    public void SelectNewPath()
    {
        _navMeshAgent.destination = path[_numPath].position;
        _navMeshAgent.Resume();
        _SelectPath = false;
    }

    void ResetAnim()
    {
        _numPath++;
        Invoke("SelectNewPath", 0.05f);
        _anim.SetBool("PickUp", false);
    }

    void SetDance()
    {
        _anim.SetBool("DanceIn", true);
    }

    void ResetDance()
    {
        _anim.SetBool("DanceIn", false);
        _anim.SetBool("DanceOut", true);        
    }

    void InvokeQuest()
    {
        gameManager.SelectQuest(4);
    }

    public void ViewBallon()
    {
        ballonDialoge.SetActive(true);
    }
}
