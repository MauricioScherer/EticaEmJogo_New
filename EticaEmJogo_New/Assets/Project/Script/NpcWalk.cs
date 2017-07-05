using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWalk : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _SelectPath;
    public int _numPath;
    private bool _viewCanvasMarket;

    public GameObject compBag;
    public ManagerLevel2 managerLevel2;
    public NpcController npcController;
    public GameObject npcCurrent;
    public Transform[] path;
    private bool _viewQuestCaixa;

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
            if(_numPath < path.Length)
            {
                if (!_SelectPath)
                {
                    if(_numPath == 0)
                    {
                        Invoke("SelectNewPath", 0.01f);
                    }
                    else if(_numPath < 4)
                    {
                        Invoke("SelectNewPath", 4f);
                    }
                    else if(_numPath == 4)
                    {
                        if(!_viewCanvasMarket)
                        {
                            if (managerLevel2.numClientFinalize == 4 && !_viewQuestCaixa)
                            {
                                managerLevel2.gameManager.SelectQuest(5);
                                _viewQuestCaixa = true;
                            }
                            else if(managerLevel2.numClientFinalize != 4 || managerLevel2.finalQuestResolve)
                            {
                                managerLevel2.ViewCanvasMarket();
                                compBag.SetActive(true);
                                _viewCanvasMarket = true;
                            }
                        }
                    }
                    else if(_numPath > 4)
                    {
                        gameObject.SetActive(false);
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

    public void FinalizeMarket()
    {
        compBag.SetActive(false);
        managerLevel2.ViewCanvasMarket();        
        _numPath++;
        SelectNewPath();
        npcController.SetEmptyBox(true);
        _SelectPath = true;
    }
}
