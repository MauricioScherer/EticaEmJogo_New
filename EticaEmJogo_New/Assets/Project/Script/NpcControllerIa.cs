using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcControllerIa : MonoBehaviour
{
    private int _numberClientInvoke;

    public bool StayCaixa;
    public AudioSource beepDoor;
    public GameObject[] npcs;

    public void InvokeNewCliente()
    {
        npcs[_numberClientInvoke].SetActive(true);
        _numberClientInvoke++;

        if (!beepDoor.isPlaying)
            beepDoor.Play();

        if (_numberClientInvoke < 5)
        {
            Invoke("InvokeNewCliente", 10f);
        }
    }
}
