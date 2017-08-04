using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJob : MonoBehaviour
{
    private bool viewArrowJob;
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
    }
}