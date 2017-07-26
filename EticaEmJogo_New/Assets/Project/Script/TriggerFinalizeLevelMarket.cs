using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalizeLevelMarket : MonoBehaviour
{
    public ManagerLevel2 managerLevel2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (managerLevel2.numClientFinalize == 5)
            {
                managerLevel2.FadeIn();
            }
        }
    }
}
