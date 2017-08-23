﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerJodLevel3 : MonoBehaviour
{
    private bool _isMoving;
    private bool _isMoving2;
    private bool _isMovingRecuse;
    private int _numBox;

    public ManagerLevel3 managerLevel;
    public float speed;
    public GameObject box;
    public Transform posIn;
    public Transform posOut;
    public Transform posOut2;
    public Cloth curtain;
    public AudioSource beepEsteira;
    public AudioSource effectCurtain;
    public AudioSource effectSteira;
    public AudioSource effectSteiraMove2;
    public float[] timeEffectCurtain;

    public GameObject canvasJob;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown("t"))
            EnterNewBox();

        if (_isMoving)
        {
            box.transform.position = Vector3.MoveTowards(box.transform.position, posOut.position, speed * Time.deltaTime);

            if(box.transform.position.x >= posOut.position.x - 0.1f)
            {
                Invoke("ViewCanvasJob", 0.5f);
                _isMoving = false;
            }
        }
        else if(_isMoving2)
        {
            box.transform.position = Vector3.MoveTowards(box.transform.position, posOut2.position, speed * Time.deltaTime);

            if (box.transform.position.z <= posOut2.position.z + 0.1f)
            {
                _isMoving2 = false;
                ResetBox(true);
            }
        }
        else if(_isMovingRecuse)
        {
            box.transform.position = Vector3.MoveTowards(box.transform.position, posIn.position, speed * Time.deltaTime);

            if (box.transform.position.x <= posIn.position.x + 0.1f)
            {
                ResetBox(false);
                _isMovingRecuse = false;
            }
        }
    }

    void ReturnBox()
    {
        curtain.enabled = true;
    }

    public void EnterNewBox()
    {
        if (!_isMoving)
        {
            Invoke("PlayEffectCurtain", timeEffectCurtain[0]);
            effectSteira.Play();
            box.SetActive(true);
            _isMoving = true;
            _numBox++;
        }
    }

    public void BoxAcept()
    {
        beepEsteira.Play();
        managerLevel.DefineLightJob(1);
        effectSteiraMove2.Play();
        _isMoving2 = true;
    }

    public void BoxRecuse()
    {
        beepEsteira.Play();
        Invoke("PlayEffectCurtain", timeEffectCurtain[1]);
        managerLevel.DefineLightJob(2);
        effectSteira.Play();
        _isMovingRecuse = true;
    }

    public void ResetBox(bool p_disableCath)
    {
        managerLevel.DefineLightJob(0);
        box.SetActive(false);
        if(p_disableCath)
        {
            curtain.enabled = false;
            Invoke("ReturnBox", 0.2f);
        }
        box.transform.position = posIn.position;

        if(canvasJob.GetComponent<Prancheta>().GetNumBox())
        {
            if(_numBox == 1)
            {
                managerLevel.AnimWokTok();
            }
            else if(_numBox == 2)
            {
                managerLevel.InvokeNpcChico();
            }
            else
            {
                Invoke("EnterNewBox", 1f);
            }
        }
        else
        {
            managerLevel.gameManager.SetMissionText();
            managerLevel.ViewArrowLockers();
            managerLevel.PlayerCanWalk(true);
        }
    }

    void ViewCanvasJob()
    {
        canvasJob.SetActive(true);
        canvasJob.GetComponent<Prancheta>().ViewBox();
    }

    void PlayEffectCurtain()
    {
        effectCurtain.Play();
    }
}
