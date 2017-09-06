using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimNpcOffice : MonoBehaviour
{
    private float timeTemp;

	void Start ()
    {        
        timeTemp = Random.Range(0, 8);
        Invoke("PlayAnim", timeTemp);
	}

    void PlayAnim()
    {
        GetComponent<Animator>().SetBool("InitializeAnim", true);
    }
}
