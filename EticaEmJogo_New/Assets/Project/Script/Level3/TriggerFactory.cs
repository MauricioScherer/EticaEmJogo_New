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

                //TODO
                //Aqui finaliza o game com esses dois metodos
                //managerLevel3.FadeMusic();
                //managerLevel3.ViewPlacarFinalLevel(true);
                managerLevel3.managerJob.gameObject.SetActive(false);
                managerLevel3.managerJob2.gameObject.SetActive(true);
                _EnterRefactory = true;
            }
        }
    }
}
