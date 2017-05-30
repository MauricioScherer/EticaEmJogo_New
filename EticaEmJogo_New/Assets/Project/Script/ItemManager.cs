using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject exclamation;

    void OnMouseEnter()
    {
        exclamation.SetActive(true);
    }

    void OnMouseExit()
    {
        exclamation.SetActive(false);
    }
}
