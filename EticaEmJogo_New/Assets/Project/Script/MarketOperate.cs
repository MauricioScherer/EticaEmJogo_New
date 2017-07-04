using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketOperate : MonoBehaviour
{
    public MarketOperateFinalize market;
    public GameObject itemBag;

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            market.StartSound(0);
            market.numItens++;
            itemBag.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
