using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerJodLevel3 : MonoBehaviour
{
    private bool _isMoving;
    private bool _analizingBox;

    public float speed;
    public GameObject box;
    public Transform posIn;
    public Transform posOut;
    public Cloth curtain;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetKeyDown("t"))
        {
            if(!_analizingBox && !_isMoving)
            {
                box.SetActive(true);
                _isMoving = true;
            }
        }

        if(Input.GetKeyDown("y"))
        {
            if(_analizingBox)
            {
                box.SetActive(false);
                curtain.enabled = false;
                box.transform.position = posIn.position;
                _analizingBox = false;
                Invoke("ReturnBox", 0.2f);
            }
        }

        if(_isMoving)
        {
            box.transform.position = Vector3.MoveTowards(box.transform.position, posOut.position, speed * Time.deltaTime);

            if(box.transform.position.x >= posOut.position.x - 0.1f)
            {
                _analizingBox = true;
                _isMoving = false;
            }
        }
	}

    void ReturnBox()
    {
        curtain.enabled = true;
    }
}
