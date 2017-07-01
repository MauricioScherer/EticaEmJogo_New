using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketOperateFinalize : MonoBehaviour
{
    public int numItens;
    public GameObject buttonOk;
    public NpcWalk npcWalk;

    void Update()
    {
        if(numItens == 4 && !buttonOk.activeSelf)
        {
            buttonOk.SetActive(true);
            numItens = 0;
        }
    }

    public void FinalizeJob()
    {
        npcWalk.FinalizeMarket();
        gameObject.SetActive(false);
    }
}
