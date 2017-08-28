﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLocker : MonoBehaviour
{
    private bool _pullEpi;
    private bool _pullEpi2;

    public ManagerLevel3 managerLevel3;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!managerLevel3.getEpi)
            {
                managerLevel3.gameManager.player.SetNewPositionPlayewr(gameObject.transform);
                managerLevel3.ViewArrowLockers();
                managerLevel3.ViewEpiMensage();
                managerLevel3.DeactiveObjetsPosScene();
                managerLevel3.getEpi = true;
                managerLevel3.ActiveExclamation(0);
                managerLevel3.ViewArrowPedro();
            }

            if(managerLevel3.gameManager.numberQuestResolve == 2 && !_pullEpi)
            {
                managerLevel3.gameManager.player.SetNewPositionPlayewr(gameObject.transform);
                managerLevel3.PlayerCanWalk(false);
                managerLevel3.ViewArrowLockers();
                managerLevel3.NpcSandro.SetActive(true);
                _pullEpi = true;
            }

            if(managerLevel3.gameManager.numberQuestResolve == 3 && !_pullEpi2)
            {
                managerLevel3.gameManager.player.SetNewPositionPlayewr(gameObject.transform);
                managerLevel3.ViewArrowLockers();
                managerLevel3.ViewEpiEmptyMensage();
                _pullEpi2 = true;
            }
        }
    }
}
