using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWalk2 : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _SelectPath;

    public int _numPath;
    public NpcControllerIa npcControllerIa;
    public GameObject npcCurrent;
    public NpcDialogue1 npcIaCaixa;
    public GameObject ballonReaction;
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
            if (_numPath < path.Length)
            {
                if (!_SelectPath)
                {
                    if(_numPath == 0)
                    {
                        _numPath++;
                        Invoke("SelectNewPath", 0.05f);
                    }
                    else if (_numPath > 0 && _numPath < 4)
                    {
                        if (_numPath == 3 && !npcControllerIa.StayCaixa)
                        {
                            _numPath++;
                            npcControllerIa.StayCaixa = true;
                        }
                        else if(_numPath == 3)
                        {
                            _numPath = 1;
                        }
                        else
                        {
                            _numPath++;
                        }

                        Invoke("SelectNewPath", 4f);
                        _anim.SetBool("ButtonPress", true);
                        Invoke("ResetAnim", 0.5f);
                    }
                    else if(_numPath == 4)
                    {
                        _numPath++;                                           
                        Invoke("ViewBallonReaction", 2f);
                        Invoke("SelectNewPath", 6f);
                    }
                    else if(_numPath >= 5)
                    {
                        gameObject.SetActive(false);
                    }
                    _SelectPath = true;
                }
            }
        }
    }

    void ViewBallonReaction()
    {
        npcIaCaixa.SetPickupFaset();
        ballonReaction.SetActive(true);
        _anim.SetBool("NoGesture", true);
        Invoke("ResetAnim", 0.5f);
    }

    void ResetAnim()
    {
        _anim.SetBool("ButtonPress", false);
        _anim.SetBool("NoGesture", false);
        npcIaCaixa.ResetPickupFaset();
    }

    void SelectNewPath()
    {
        _navMeshAgent.destination = path[_numPath].position;
        _navMeshAgent.Resume();
        if (ballonReaction.activeSelf)
            ballonReaction.SetActive(false);
        _SelectPath = false;
        if(_numPath >= 5)
        {
            npcControllerIa.StayCaixa = false;
        }
    }
}
