using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    private Animator _anim;
    private bool _stayMouseAvatar;
    private bool _waveActive;

    void Start ()
    {
        _anim = GetComponent<Animator>();
    }
	
	void Update ()
    {

	}

    void OnMouseEnter()
    {
        if(!_stayMouseAvatar)
        {
            _anim.SetBool("Wave", true);
            _stayMouseAvatar = true;
            Invoke("SetAnimation", 1f);
        }
    }

    void OnMouseExit()
    {
        _anim.SetBool("Wave", false);
        _stayMouseAvatar = false;
    }

    void SetAnimation()
    {
        if (_stayMouseAvatar)
        {
            _anim.SetBool("Wave", false);
            _stayMouseAvatar = false;
        }
    }
}
