using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFactory : MonoBehaviour
{
    private bool _EnterRefactory;

    public ManagerLevel3 managerLevel3;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!_EnterRefactory && managerLevel3.GetEnterRefactory())
            {
                managerLevel3.ViewArrowRefactory();
                managerLevel3.gameManager.ResetMissionText();
                managerLevel3.FadeIn();
                _EnterRefactory = true;
            }
        }
    }
}
