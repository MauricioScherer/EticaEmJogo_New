using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWalk : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _SelectPath;
    private int _numPath;

    public NpcController npcController;
    public GameObject npcCurrent;
    public Transform[] path;

    void Awake()
    {
        _anim = npcCurrent.GetComponent<Animator>();
        _navMeshAgent = npcCurrent.GetComponent<NavMeshAgent>();
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
            if(_numPath < path.Length - 1)
            {
                if (!_SelectPath)
                {
                    if(_numPath == 0)
                    {
                        Invoke("SelectNewPath", 0.01f);
                    }
                    else if(_numPath < 4)
                    {
                        Invoke("SelectNewPath", 5f);
                    }
                    else if(_numPath == 4)
                    {
                        if(Input.GetKeyDown("t"))
                        {
                            _numPath++;
                            SelectNewPath();
                            npcController.SetEmptyBox(true);
                            _SelectPath = true;
                        }
                    }
                    if (_numPath > 0 && _numPath < 4)
                    {
                        _anim.SetBool("ButtonPress", true);
                        Invoke("ResetAnim", 0.5f);
                    }
                    if(_numPath < 4)
                    {
                        if(_numPath == 3)
                        {
                            if (npcController.GetEmptyBox())
                            {
                                _numPath++;
                                npcController.SetEmptyBox(false);
                            }
                            else
                            {
                                _numPath = 1;
                            }
                        }
                        else
                        {
                            _numPath++;
                        }
                        _SelectPath = true;
                    }
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    void SelectNewPath()
    {
        _navMeshAgent.destination = path[_numPath].position;
        _navMeshAgent.Resume();
        _SelectPath = false;
    }

    void ResetAnim()
    {
        _anim.SetBool("ButtonPress", false);
    }
}
