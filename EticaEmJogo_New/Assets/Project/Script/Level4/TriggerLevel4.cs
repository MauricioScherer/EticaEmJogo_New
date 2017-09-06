using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevel4 : MonoBehaviour
{
    private bool initializeJob1;

    public ManagerLevel4 managerLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(managerLevel.gameManager.numberQuestResolve == 1 && !initializeJob1)
            {
                managerLevel.ViewArrowJob();
                managerLevel.FadeIn();
                managerLevel.PlayerCanWalk(false);
                initializeJob1 = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
