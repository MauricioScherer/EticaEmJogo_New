using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerJodLevel3 : MonoBehaviour
{
    private bool _isMoving;
    private bool _isMoving2;
    private bool _isMovingRecuse;

    public float speed;
    public GameObject box;
    public Transform posIn;
    public Transform posOut;
    public Transform posOut2;
    public Cloth curtain;

    public GameObject canvasJob;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetKeyDown("t"))
        {
            EnterNewBox();
        }

        if (Input.GetKeyDown("y"))
        {
            BoxAcept();
        }

        if (Input.GetKeyDown("i"))
        {
            BoxRecuse();
        }

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
            box.SetActive(true);
            _isMoving = true;
        }
    }

    public void BoxAcept()
    {
        _isMoving2 = true;
    }

    public void BoxRecuse()
    {
        _isMovingRecuse = true;
    }

    public void ResetBox(bool p_disableCath)
    {
        box.SetActive(false);
        if(p_disableCath)
        {
            curtain.enabled = false;
            Invoke("ReturnBox", 0.2f);
        }
        box.transform.position = posIn.position;

        if(canvasJob.GetComponent<Prancheta>().GetNumBox())
        {
            Invoke("EnterNewBox", 1f);
        }
    }

    void ViewCanvasJob()
    {
        canvasJob.SetActive(true);
        canvasJob.GetComponent<Prancheta>().ViewBox();
    }

    
}
