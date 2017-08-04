using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prancheta : MonoBehaviour
{
    private int _numBox;

    public ManagerJodLevel3 manageJob;
    public GameObject buttonNext;
    public GameObject buttonBack;
    public GameObject[] pag;
    public GameObject[] box;

    public void NextPag()
    {
        pag[0].SetActive(false);
        pag[1].SetActive(true);
        buttonNext.SetActive(false);
        buttonBack.SetActive(true);
    }

    public void BackPag()
    {
        pag[0].SetActive(true);
        pag[1].SetActive(false);
        buttonNext.SetActive(true);
        buttonBack.SetActive(false);
    }

    public void AceptBox()
    {
        manageJob.BoxAcept();
        box[_numBox - 1].SetActive(false);
        gameObject.SetActive(false);
    }

    public void RecuseBox()
    {
        manageJob.BoxRecuse();
        box[_numBox - 1].SetActive(false);
        gameObject.SetActive(false);
    }

    public void ViewBox()
    {
        if(_numBox < box.Length)
        {
            box[_numBox].SetActive(true);
            _numBox++;
        }
    }

    public bool GetNumBox()
    {
        if (_numBox < box.Length)
            return true;
        else
            return false;
    }
}
