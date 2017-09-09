using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevel4 : MonoBehaviour
{
    private bool initializeJob1;
    private bool initializeJob2;

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
                managerLevel.Deactiveobj(0);
                managerLevel.Deactiveobj(1);
                initializeJob1 = true;
            }
            else if (managerLevel.gameManager.numberQuestResolve == 3 && !initializeJob2)
            {
                managerLevel.ViewArrowJob();
                managerLevel.FadeIn();
                managerLevel.PlayerCanWalk(false);
                initializeJob2 = true;
            }
        }
    }
}
