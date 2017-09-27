using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAnimFinalLevel : MonoBehaviour
{
    public Transform cameraPosition;
    public Animator cameraAnim;
    public GameObject animPart1;
    public GameObject animPart2;
    public GameObject animPart3;

    public Transform positionCamera2;
    public Transform positionCamera3;

    public GameObject fade;
    public GameObject fadeIn;
    public float timeActiveFade1;
    public float timeDeactiveFade;
    public float timeActiveFade2;
    public float timeActiveFade3;

    void Start ()
    {
        Invoke("ActiveFade", timeActiveFade1);
        fadeIn.SetActive(true);
    }
	
	void Update ()
    {
		
	}

    void ActiveFade()
    {
        fade.SetActive(true);
        Invoke("DeactiveFade", timeDeactiveFade);
        if (animPart1.activeSelf)
        {            
            Invoke("ActivePart2", timeDeactiveFade / 2);
        }
        else if(animPart2.activeSelf)
        {
            Invoke("ActivePart3", timeDeactiveFade / 2);
        }
    }

    void DeactiveFade()
    {
        fade.SetActive(false);
    }

    void ActivePart2()
    {
        cameraPosition.position = positionCamera2.position;
        cameraAnim.SetBool("Cam2", true);
        animPart1.SetActive(false);
        animPart2.SetActive(true);
        Invoke("ActiveFade", timeActiveFade2);
    }

    void ActivePart3()
    {
        cameraPosition.position = positionCamera3.position;
        cameraAnim.SetBool("Cam3", true);
        animPart2.SetActive(false);
        animPart3.SetActive(true);
        Invoke("ActiveFade", timeActiveFade3);
    }
}
