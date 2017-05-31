using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _npcClicked;
    private bool _stayQuest;
    private bool _itemSelect;
    private bool _getWallet;
    private bool _canWalk;
    private bool _inDirectionPersonWallet;
    private int _numberQuestSelect;
    private GameObject _objTemp;

    public GameManager gameManager;
    public Transform avatarWallet;
    public bool deliverWallet;

    void Awake ()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _canWalk = true;
    }
	
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButton(0) && !_npcClicked && !_itemSelect && !_getWallet && _canWalk)
        {
            if (Physics.Raycast(ray, out hit, 100))
            {                
                if (hit.collider.CompareTag("npc") &&
                    !hit.collider.GetComponent<NpcManager>().questResolved &&
                    hit.collider.GetComponent<NpcManager>().GetQuestStay() != 0)
                {                    
                    hit.collider.GetComponent<NpcManager>().questResolved = true;
                    _numberQuestSelect = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                    Invoke("ActivateClickNpc", 0.1f);
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
                }
                _navMeshAgent.destination = hit.point;
                _navMeshAgent.Resume();
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
    void ActivateClickWallet()
    {
        _itemSelect = true;
    }
}
