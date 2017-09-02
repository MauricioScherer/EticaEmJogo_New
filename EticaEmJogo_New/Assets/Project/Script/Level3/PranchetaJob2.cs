using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PranchetaJob2 : MonoBehaviour
{
    private int _numBox;

    public ManagerJod2Level3 manageJob;
    public GameObject[] box;

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
