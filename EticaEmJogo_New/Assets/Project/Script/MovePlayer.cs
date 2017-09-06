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
    private bool _viewMural;
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

                    if (gameManager.GetNumberScene() == 1)
                    {
                        if (!__questResolved)
                        {
                            if (__questStay != 0 && __stateCurrent != 4 && gameManager.numberQuestResolve == __questStay)
                            {
                                hit.collider.GetComponent<NpcManager>().questResolved = true;
                                _numberQuestSelect = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                                Invoke("ActivateClickNpc", 0.05f);
                            }
                            else if (__stateCurrent == 1)
                            {
                                _objTemp = hit.collider.gameObject;
                                Invoke("ActiveClickDialogue", 0.05f);
                            }
                        }
                    }
                    else if(gameManager.GetNumberScene() == 3)
                    {
                        if (!__questResolved)
                        {
                            if (__questStay == 1 && gameManager.managerLevel2.GetNumberQuestResolve() == 1)
                            {
                                hit.collider.GetComponent<NpcManager>().questResolved = true;
                                _numberQuestSelect = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                                _objTemp = hit.collider.gameObject;
                                Invoke("ActivateClickNpc", 0.05f);
                            }
                            else if(__questStay == 2 && gameManager.managerLevel2.GetNumberQuestResolve() == 2)
                            {
                                hit.collider.GetComponent<NpcManager>().questResolved = true;
                                _numberQuestSelect = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                                _objTemp = hit.collider.gameObject;
                                Invoke("ActivateClickNpc", 0.05f);
                            }
                        }
                    }
                    else if(gameManager.GetNumberScene() == 4)
                    {
                        if (!__questResolved)
                        {
                            if (__questStay == 1 && gameManager.numberQuestResolve == 1 && !gameManager.managerLevel3.dialogueNpcPedro)
                            {
                                hit.collider.GetComponent<NpcManager>().questResolved = true;
                                _numberQuestSelect = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                                _objTemp = hit.collider.gameObject;
                                gameManager.managerLevel3.dialogueNpcPedro = true;
                                Invoke("ActivateClickNpc", 0.05f);
                            }
                            if (__questStay == 6 && gameManager.numberQuestResolve == 6)
                            {
                                hit.collider.GetComponent<NpcManager>().questResolved = true;
                                _numberQuestSelect = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                                _objTemp = hit.collider.gameObject;
                                Invoke("ActivateClickNpc", 0.05f);
                            }
                        }
                    }
                    else if (gameManager.GetNumberScene() == 5)
                    {
                        if (!__questResolved)
                        {
                            if (gameManager.numberQuestResolve == 0)
                            {
                                hit.collider.GetComponent<NpcManager>().questResolved = true;
                                _numberQuestSelect = hit.collider.GetComponent<NpcManager>().GetQuestStay();
                                _objTemp = hit.collider.gameObject;
                                gameManager.managerLevel4.selectNpcAna = true;
                                Invoke("ActivateClickNpc", 0.05f);
                            }
                        }
                    }
                }
                else if(hit.collider.CompareTag("Wallet"))
                {                    
                    _numberQuestSelect = 0;
                    _objTemp = hit.collider.gameObject;
                    Invoke("ActivateClickWallet", 0.05f);
                }
                else if(hit.collider.CompareTag("Mural"))
                {
                    Invoke("ActiveClickMural", 0.05f);
                }
                else
                {
                    _npcClicked = false;
                    _itemSelect = false;
                    _getWallet = false;
                    _canWalk = true;
                    _dialogueBalon = false;
                    _viewMural = false;
                    _objTemp = null;                    
                }
                if(gameManager.GetNumberScene() == 5)
                {
                    if(gameManager.numberQuestResolve == 0 && gameManager.managerLevel4.selectNpcAna)
                    {
                        _navMeshAgent.destination = gameManager.managerLevel4.posDialogueNpc.position;
                    }
                    else
                    {
                        _navMeshAgent.destination = hit.point;
                    }
                }
                else
                {
                    _navMeshAgent.destination = hit.point;
                } 
                _navMeshAgent.isStopped = false;
                particleClikPosition.position = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
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
                    //_navMeshAgent.Resume();
                    _navMeshAgent.isStopped = false;
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
            if(gameManager.GetNumberScene() == 1)
            {
                if (_npcClicked || _itemSelect)
                {
                    if (_objTemp != null)
                    {
                        _objTemp.SetActive(false);
                    }
                    gameManager.SelectQuest(_numberQuestSelect);
                    _stayQuest = true;
                }
                else if (_getWallet && _inDirectionPersonWallet)
                {
                    avatarWallet.gameObject.GetComponent<NpcManager>().SetAnimVictory();
                    avatarWallet.gameObject.GetComponent<NpcManager>().questResolved = true;
                    gameManager.managerLevel.ActiveExclamation(0);
                    gameManager.managerLevel.ActiveExclamation(1);
                    SetValues();
                }
                else if (_dialogueBalon)
                {
                    if (_objTemp != null)
                    {
                        _objTemp.GetComponent<NpcManager>().ViewBalonDialogue();
                    }
                    SetValues();
                }
            }
            else if(gameManager.GetNumberScene() == 3)
            {
                if(_npcClicked)
                {
                    if(_numberQuestSelect == 1)
                    {
                        if (_objTemp != null)
                        {
                            _objTemp.GetComponent<NpcManager>().ballonDialogue[1].SetActive(true);
                            if(gameManager.managerLevel2)
                            {
                                gameManager.managerLevel2.ActiveExclamation(0);
                                gameManager.managerLevel2.ActiveExclamation(1);
                            }
                            _objTemp = null;
                        }
                    }
                    else if(_numberQuestSelect == 2)
                    {
                        if (_objTemp != null)
                        {
                            _objTemp.GetComponent<NpcManager>().ballonDialogue[2].SetActive(true);
                            if (gameManager.managerLevel2)
                            {
                                gameManager.managerLevel2.ActiveExclamation(1);
                            }
                            _objTemp = null;
                        }
                    }
                }
                else if (_viewMural)
                {
                    gameManager.managerLevel2.ViewCanvasMural(true);
                    gameManager.DeactiveHudAndPause();
                    _viewMural = false;
                }
            }
            else if(gameManager.GetNumberScene() == 4)
            {
                if (_npcClicked)
                {
                    if (_numberQuestSelect == 1)
                    {
                        if (_objTemp != null)
                        {
                            _objTemp.GetComponent<NpcManager>().ballonDialogue[0].SetActive(true);
                            gameManager.managerLevel3.ActiveExclamation(0);
                            gameManager.managerLevel3.ViewArrowPedro();
                            _objTemp = null;
                        }
                    }
                    else if (_numberQuestSelect == 6)
                    {
                        if (_objTemp != null)
                        {
                            _objTemp.GetComponent<NpcManager>().ballonDialogue[0].SetActive(true);
                            gameManager.managerLevel3.ActiveExclamation(1);
                            _objTemp = null;
                        }
                    }
                }
            }
            else if(gameManager.GetNumberScene() == 5)
            {
                if (_npcClicked)
                {
                    if (_numberQuestSelect == 0)
                    {
                        if (_objTemp != null)
                        {
                            _objTemp.GetComponent<NpcManager>().ballonDialogue[0].SetActive(true);
                            gameManager.managerLevel4.ActiveExclamation(0);
                            gameManager.numberQuestResolve = 1;
                            _objTemp = null;
                        }
                    }
                }
            }
        }
    }

    void MovePersonWallet()
    {
        _inDirectionPersonWallet = true;
    }

    public void CanWalk(bool p_canWalk)
    {
        _canWalk = p_canWalk;
    }

    public bool GetCanWalk()
    {
        return _canWalk;
    }

    public void SetValues()
    {
        _npcClicked = false;
        _canWalk = true;
        _itemSelect = false;
        _stayQuest = false;
        _viewMural = false;
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
    void ActiveClickMural()
    {
        _viewMural = true;
        CanWalk(false);
    }

    public void SetNewPositionPlayewr(Transform p_position)
    {
        _navMeshAgent.destination = p_position.position;
        //_navMeshAgent.Resume();
        _navMeshAgent.isStopped = false;
    }

    public void SetAnimYesGesture()
    {
        _anim.SetBool("YesGesture", true);
        Invoke("ResetAnim", 0.2f);
    }

    void ResetAnim()
    {
        if(_anim.GetBool("YesGesture"))
            _anim.SetBool("YesGesture", false);
        if (_anim.GetBool("ButtonPress"))
            _anim.SetBool("ButtonPress", false);
    }

    public void SetAnimButtonPress()
    {
        _anim.SetBool("ButtonPress", true);
        Invoke("ResetAnim", 0.2f);
    }
}
