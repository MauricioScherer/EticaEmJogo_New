using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] npcs;
    private bool emptyBox;

    void Awake()
    {
        emptyBox = true;
    }

    public bool GetEmptyBox()
    {
        return emptyBox;
    }
    public void SetEmptyBox(bool p_status)
    {
        emptyBox = p_status;
    }
}
