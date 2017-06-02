using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public ManagerLevel managerLevel;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("TriggerAction"))
            {
                if(managerLevel.ResolveTotalQuests())
                {
                    Debug.Log("mostrar feedback");
                    gameObject.SetActive(false);
                }
            }
            else
            {
                managerLevel.NewInstruction();
                gameObject.SetActive(false);
            }            
        }
    }
}
