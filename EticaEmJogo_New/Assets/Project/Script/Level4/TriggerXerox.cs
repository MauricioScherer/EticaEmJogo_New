using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerXerox : MonoBehaviour
{
    private bool enterAreaXerox;

    public ManagerLevel4 managerLevel;
    public GameObject ballonAlberto;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (managerLevel.gameManager.numberQuestResolve == 2 && !enterAreaXerox)
            {
                managerLevel.ViewArrowJob();
                managerLevel.PlayerCanWalk(false);
                managerLevel.ViewArrowXerox();
                managerLevel.gameManager.ResetMissionText();
                ballonAlberto.SetActive(true);
                enterAreaXerox = true;
            }
        }
    }
}
