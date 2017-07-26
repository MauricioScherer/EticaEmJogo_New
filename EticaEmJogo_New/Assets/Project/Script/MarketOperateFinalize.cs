using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketOperateFinalize : MonoBehaviour
{
    private AudioSource sound;

    public int numItens;
    public AudioClip[] clipEffect;
    public GameObject buttonOk;
    public NpcWalk npcWalk;
    public ManagerLevel2 managerLevel2;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(numItens == 4 && !buttonOk.activeSelf)
        {
            StartSound(1);
            buttonOk.SetActive(true);
            numItens = 0;
        }
    }

    public void FinalizeJob()
    {
        npcWalk.FinalizeMarket();
        managerLevel2.numClientFinalize++;
        if (managerLevel2.numClientFinalize == 5)
        {
            managerLevel2.gameManager.SetMissionFinalLevelMarket();
        }
        gameObject.SetActive(false);
    }

    public void StartSound(int p_clip)
    {
        sound.clip = clipEffect[p_clip];
        sound.Play();
    }
}
