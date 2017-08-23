using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcDialogue1 : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _SelectPath;
    private int _numPath;
    public int _numDialogueStandActivate;

    public bool isMove;
    public GameManager gameManager;
    public ManagerLevel2 managerLevel2;
    public GameObject ballonDialoge;
    public GameObject[] ballonStand;
    public GameObject npcCurrent;
    public Transform positionCaixa;
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
                if (_numPath < path.Length)
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
                            if(_numPath < 4)
                                Invoke("SelectNewPath", 0.05f);                            
                        }                                             
                        _SelectPath = true;
                    }
                }
                else
                {
                    Invoke("SetDance", 1f);
                    Invoke("ResetDance", 3f);
                    Invoke("InvokeQuest", 6f);
                    isMove = false;
                }
            }
        }
    }

    void ViewBallonDialogueStand()
    {    
        if(_numDialogueStandActivate < ballonStand.Length)
        {
            if(_numDialogueStandActivate != 0)
                ballonStand[_numDialogueStandActivate - 1].SetActive(false);
            ballonStand[_numDialogueStandActivate].SetActive(true);
            _numDialogueStandActivate++;
            Invoke("ViewBallonDialogueStand", 4.7f);
        }
        else
        {
            ballonStand[_numDialogueStandActivate - 1].SetActive(false);
        }
    }

    public void ActiveBallonStand()
    {
        Invoke("ViewBallonDialogueStand", 3f);
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
        GetComponent<AudioSource>().Play();
    }

    void ResetDance()
    {
        _anim.SetBool("DanceIn", false);
        _anim.SetBool("DanceOut", true);        
    }

    public void SetPickupFaset()
    {
        _anim.SetBool("PickUpFast", true);
    }

    public void ResetPickupFaset()
    {
        _anim.SetBool("PickUpFast", false);
    }

    void InvokeQuest()
    {
        gameManager.SelectQuest(4);
        npcCurrent.transform.rotation = positionCaixa.rotation;
    }

    public void ViewBallonDialogueInitial()
    {
        ballonDialoge.SetActive(true);
    }
}
