using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJob : MonoBehaviour
{
    private bool viewArrowJob;
    private bool viewArrowJob2;
    public ManagerLevel3 managerLevel3;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !viewArrowJob && managerLevel3.dialogueNpcPedro)
        {
            managerLevel3.ViewArrowJob();
            managerLevel3.InitializeJob();
            managerLevel3.gameManager.player.SetNewPositionPlayewr(gameObject.transform);
            viewArrowJob = true;
        }

        if(other.CompareTag("Player") && !viewArrowJob2 && managerLevel3.gameManager.numberQuestResolve == 4)
        {
            managerLevel3.gameManager.player.SetNewPositionPlayewr(gameObject.transform);
            managerLevel3.ViewArrowJob();
            managerLevel3.gameManager.ResetMissionText();
            managerLevel3.InitializeJob2();
            viewArrowJob2 = true;
        }
    }
}