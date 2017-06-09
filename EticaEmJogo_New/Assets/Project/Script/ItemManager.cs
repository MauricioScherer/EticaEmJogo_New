using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject exclamation;
    public GameManager gameManager;

    void OnMouseEnter()
    {
        if(!gameManager.isPlayEffect())
            gameManager.PlayEffect(4);
        exclamation.SetActive(true);
    }

    void OnMouseExit()
    {
        exclamation.SetActive(false);
    }
}
