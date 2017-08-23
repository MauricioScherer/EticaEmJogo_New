using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private bool _emptyBox;
    private int _numberClientInvoke;
    
    public GameManager gameManager;
    public AudioSource beepDoor;
    public GameObject[] npcs;

    void Awake()
    {
        _emptyBox = true;
    }

    public bool GetEmptyBox()
    {
        return _emptyBox;
    }
    public void SetEmptyBox(bool p_status)
    {
        _emptyBox = p_status;
    }

    public void InvokeNewCliente()
    {
        npcs[_numberClientInvoke].SetActive(true);
        _numberClientInvoke++;

        if (!beepDoor.isPlaying)
            beepDoor.Play();

        if(_numberClientInvoke < npcs.Length)
        {
            Invoke("InvokeNewCliente", 10f);
        }
    }
}
