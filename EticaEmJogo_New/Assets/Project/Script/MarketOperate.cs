using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketOperate : MonoBehaviour
{
    private int _numberPosition;
    
    public GameObject[] listItemBag;
    public GameObject[] listItens;

    public void Start()
    {
        listItens[_numberPosition].SetActive(true);
        listItens[_numberPosition].GetComponent<Animator>().SetBool("ItemIn", true);
        Invoke("ResetAnim", 0.5f);

    }

    public void ItemIn()
    {
        listItens[_numberPosition].GetComponent<Animator>().SetBool("ItemIn", true);
    }

    public void ItemOut()
    {
        listItens[_numberPosition].GetComponent<Animator>().SetBool("ItemOut", true);
        listItemBag[_numberPosition].SetActive(true);
        _numberPosition++;        
    }

    void ResetAnim()
    {
        listItens[_numberPosition].GetComponent<Animator>().SetBool("ItemIn", false);
        listItens[_numberPosition].GetComponent<Animator>().SetBool("ItemOut", false);
    }
}
