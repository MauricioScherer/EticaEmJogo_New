using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private GameObject _objTemp;
    private Transform particleClikPosition;
    private bool _npcClicked;
    private bool _stayQuest;
    private bool _itemSelect;
    private bool _getWallet;
    private bool _canWalk;
    private bool _inDirectionPersonWallet;
    private bool _dialogueBalon;
    private int _numberQuestSelect;

    public GameManager gameManager;
    public Transform avatarWallet;
    public bool deliverWallet;
    public ParticleSystem particleClick;

    void Awake ()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _canWalk = true;
        particleClikPosition = particleClick.gameObject.transform;
    }
	
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButton(0) && !_npcClicked && !_itemSelect && !_getWallet && _canWalk)
        {
            if (Physics.Raycast(ray, out hit, 100))
            {                    
                if (hit.collider.CompareTag("npc"))
                {
                    bool __questResolved = hit.collider.GetComponent<NpcManager>().questResolved;
                    int __questStay = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                    int __stateCurrent = hit.collider.GetComponent<NpcManager>().GetStateCurrent();

                    if (!__questResolved)
                    {
                        if(__questStay != 0)
                        {
                            hit.collider.GetComponent<NpcManager>().questResolved = true;
                            _numberQuestSelect = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                            Invoke("ActivateClickNpc", 0.1f);
                        }
                        else if(__stateCurrent == 1)
                        {
                            _objTemp = hit.collider.gameObject;
                            Invoke("ActiveClickDialogue", 0.1f);
                        }
                    }                    
                }
                else if(hit.collider.CompareTag("Wallet"))
                {                    
                    _numberQuestSelect = 0;
                    _objTemp = hit.collider.gameObject;
                    Invoke("ActivateClickWallet", 0.1f);
                }
                else
                {
                    _npcClicked = false;
                    _itemSelect = false;
                    _getWallet = false;
                    _canWalk = true;
                    _dialogueBalon = false;
                    _objTemp = null;                    
                }
                _navMeshAgent.destination = hit.point;
                _navMeshAgent.Resume();
                particleClikPosition.position = new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z);
                particleClick.Play();                               
            }
        }
        else if(_getWallet)
        {
            if(avatarWallet != null)
            {
                if (deliverWallet)
                {
                    Invoke("MovePersonWallet", 0.5f);
                    _navMeshAgent.destination = avatarWallet.position;
                    _navMeshAgent.Resume();
                }
                else
                {
                    SetValues();
                }
            }
        }

        if(Input.GetMouseButtonDown(0) && _canWalk && !_stayQuest)
        {
            if (!gameManager.isPlayEffect()) gameManager.PlayEffect(0);
        }

        if(_navMeshAgent.remainingDistance > 0.2f)
        {
            _anim.SetFloat("MoveSpeed", _navMeshAgent.speed);
        }
        else
        {
            _anim.SetFloat("MoveSpeed", 0);
        }

        if (_navMeshAgent.remainingDistance <= 0.2f && !_stayQuest)
        {
            if (_npcClicked || _itemSelect)
            {
                if (_objTemp != null)
                    _objTemp.SetActive(false);
                gameManager.SelectQuest(_numberQuestSelect);
                _stayQuest = true;
            }
            else if(_getWallet && _inDirectionPersonWallet)
            {                
                avatarWallet.gameObject.GetComponent<NpcManager>().SetAnimVictory();
                avatarWallet.gameObject.GetComponent<NpcManager>().questResolved = true;
                SetValues();
            }
            else if(_dialogueBalon)
            {
                if (_objTemp != null)
                    _objTemp.GetComponent<NpcManager>().ViewBalonDialogue();
                SetValues();
            }
        }
    }

    void MovePersonWallet()
    {
        _inDirectionPersonWallet = true;
    }

    public void CanWalk()
    {
        _canWalk = !_canWalk;
    }

    public void SetValues()
    {
        _npcClicked = false;
        _canWalk = true;
        _itemSelect = false;
        _stayQuest = false;
        if (_objTemp != null)
        {
            _objTemp = null;
            _getWallet = true;
        }
        else
        {
            _getWallet = false;
            _inDirectionPersonWallet = false;
        }
    }

    void ActivateClickNpc()
    {
        _npcClicked = true;
    }
    void ActiveClickDialogue()
    {
        _dialogueBalon = true;
    }
    void ActivateClickWallet()
    {
        _itemSelect = true;
    }
}
