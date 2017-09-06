using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensagerManager : MonoBehaviour
{
    public int count;
    public GameObject[] mensage1;
    public GameObject[] mensage2;
    public GameObject newMensager;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void ViewMensages()
    {
        for (int i = 0; i < mensage1.Length; i++)
        {
            if(!mensage1[i].activeSelf && !mensage1[mensage1.Length - 1].activeSelf)
            {
                mensage1[i].SetActive(true);
                mensage1[i].GetComponent<AudioSource>().Play();                
                Invoke("ViewMensages", 4f);
                break;
            }
        }        
    }
    public void ViewMensage2()
    {
        for (int i = 0; i < mensage2.Length; i++)
        {
            if (!mensage2[i].activeSelf && !mensage2[mensage2.Length - 1].activeSelf)
            {
                mensage2[i].SetActive(true);
                mensage2[i].GetComponent<AudioSource>().Play();
                Invoke("ViewMensage2", 4f);
                break;
            }
        }
    }

    public void CountNewMensage2()
    {
        count++;
        if(count == 3)
        {
            DeactiveMensage1();
            Invoke("ViewSimbolNewMensage", 2f);
            Invoke("ViewMensage2", 2f);
        }
    }

    public void DeactiveMensage1()
    {
        for (int i = 0; i < mensage1.Length; i++)
        {
            mensage1[i].SetActive(false);
        }
    }

    public bool GetStayVisibolSimbol()
    {
        if (!newMensager.activeSelf)
            return false;
        else
            return true;
    }

    public void ViewSimbolNewMensage()
    {
        if (!newMensager.activeSelf)
            newMensager.SetActive(true);
        else
            newMensager.SetActive(false);
    }
}
