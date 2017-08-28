using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelularManager : MonoBehaviour
{
    private bool _stayCelular;
    private Animator _anim;

    public GameObject celularView;
    public ManagerLevel managerLevel;
    public GameObject[] mensage;
    public GameManager gameManager;
    
	void Awake ()
    {
        _anim = GetComponent<Animator>();
    }

    public void ViewCelular()
    {
        if (!celularView.activeSelf)
        {
            ViewInstructionPhone(0);
            celularView.SetActive(true);            
            _stayCelular = true;
            if (_anim.GetBool("Walk"))
                _anim.SetBool("Walk", false);
        }
        else
        {
            celularView.SetActive(false);
            _stayCelular = false;

            if (gameManager.GetNumberScene() == 1)
            {
                if (gameManager.numberQuestResolve == 1 && !managerLevel.GetviewMensageMissionPhone())
                {
                    gameManager.SetMissionText();
                    managerLevel.SetviewMensageMissionPhone();
                }
            }
        }
        gameManager.PlayEffect(3);
    }

    public void DeactiveView()
    {
        if (_stayCelular)
        {
            celularView.SetActive(false);
            _stayCelular = false;
        }
    }

    public void EnterWalkState()
    {
        gameManager.player.CanWalk(false);
    }

    public void ExitWalkState()
    {
        if(!_stayCelular)
        {
            if(gameManager.managerLevel2)
            {
                if(gameManager.managerLevel2.quest1Resolve)
                {
                    gameManager.player.CanWalk(true);
                }
            }
            else
            {
                gameManager.player.CanWalk(true);
            }                
        }
    }

    public void SetMensage(int p_mensageActive)
    {
        GetComponent<AudioSource>().Play();
        ViewInstructionPhone(p_mensageActive);
        _anim.SetBool("Walk", true);
        mensage[p_mensageActive].SetActive(true);
    }

    public void CleanMensage()
    {
        for(int i = 0; i < mensage.Length; i++)
        {
            mensage[i].SetActive(false);
        }
    }

    public void PlayMovie()
    {
        if(managerLevel)
        {
            if (managerLevel.GetNumberQuestResolve() == 1)
            {
                managerLevel.SelectEventGameManager();
                celularView.SetActive(false);
                _stayCelular = false;
            }
        }
    }

    void ViewInstructionPhone(int p_temp)
    {
        if (gameManager.GetNumberScene() == 1 && p_temp == 0)
        {
            if (managerLevel.instructionPhone)
            {
                if(!managerLevel.ViewInstructionPhone)
                {
                    if (!managerLevel.instructionPhone.activeSelf)
                    {
                        managerLevel.instructionPhone.SetActive(true);
                    }
                    else
                    {
                        managerLevel.instructionPhone.SetActive(false);
                        managerLevel.ViewInstructionPhone = true;
                    }
                }
            }
        }
    }
}
