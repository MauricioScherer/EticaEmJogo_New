using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensagerManagerJob2 : MonoBehaviour
{
    public bool finalizeMensage1;
    public bool visualizeMensage;
    public int count;
    public GameObject[] mensage1;
    public GameObject newMensager;

    public void ViewMensages()
    {
        for (int i = 0; i < mensage1.Length; i++)
        {
            if (!mensage1[i].activeSelf && !mensage1[mensage1.Length - 1].activeSelf)
            {
                mensage1[i].SetActive(true);
                if(visualizeMensage)
                    mensage1[i].GetComponent<AudioSource>().Play();
                if (i >= mensage1.Length - 1)
                {
                    finalizeMensage1 = true;
                }
                Invoke("ViewMensages", 3f);
                break;
            }
        }
    }

    public void CountNewMensage1()
    {
        count++;
        if (count == 3)
        {
            ViewSimbolNewMensage();
            ViewMensages();
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
