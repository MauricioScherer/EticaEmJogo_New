using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class IntroMovePlayer : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private bool _fadeIn;
    private Color _colorFade;

    public IntroMarketManager manager;
    public Image fade;
    public Transform destinationMarket;

    void Awake ()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _navMeshAgent.destination = destinationMarket.position;
        //_navMeshAgent.Resume();
        _navMeshAgent.isStopped = false;
    }
	
	void Update ()
    {
        if (_navMeshAgent.remainingDistance < 8f && !_fadeIn)
        {
            fade.color = _colorFade;
            _colorFade.a += 0.4f * Time.deltaTime;
            manager.music.volume -= 0.025f * Time.deltaTime;

            if (_colorFade.a >= 1)
            {
                manager.LoadNewScene();
                _fadeIn = true;
            }
        }


        if (_navMeshAgent.remainingDistance > 0.2f)
        {
            _anim.SetFloat("MoveSpeed", _navMeshAgent.speed);
        }
        else
        {
            _anim.SetFloat("MoveSpeed", 0);
        }
    }
}
