using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelularManager : MonoBehaviour
{
    private bool _stayCelular;
    private Animator _anim;

    public GameObject celularView;
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
            celularView.SetActive(true);
            _stayCelular = true;
            if (_anim.GetBool("Walk"))
                _anim.SetBool("Walk", false);
        }
        else
        {
            celularView.SetActive(false);
            _stayCelular = false;
        }
        gameManager.PlayEffect(3);
    }

    public void DeactiveView()
    {
        if (_stayCelular)
        {
            celularView.SetActive(false);
            _stayCelular = false;
            WalkState();
        }
    }

    public void WalkState()
    {
        if(!_stayCelular)
        {
            gameManager.player.CanWalk();
        }
    }

    public void SetMensage(int p_mensageActive)
    {
        GetComponent<AudioSource>().Play();
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
}
