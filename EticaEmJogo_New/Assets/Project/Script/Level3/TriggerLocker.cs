using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLocker : MonoBehaviour
{
    public ManagerLevel3 managerLevel3;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!managerLevel3.getEpi)
            {
                managerLevel3.ViewArrowLockers();
                managerLevel3.ViewEpiMensage();
                managerLevel3.getEpi = true;
            }
        }
    }
}
