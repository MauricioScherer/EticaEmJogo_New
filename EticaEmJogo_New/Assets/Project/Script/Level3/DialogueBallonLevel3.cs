using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBallonLevel3 : MonoBehaviour
{
    public GameManager gameManager;
    public ManagerLevel3 managerLevel;
    public AudioSource voiceNpc;
    public NpcSandro npcCurrent;
    public GameObject[] textDialogue;

    public void ConfirmDialogue()
    {
        for (int i = 0; i < textDialogue.Length; i++)
        {
            if (i < textDialogue.Length - 1)
            {
                if (textDialogue[i].activeSelf)
                {
                    textDialogue[i].SetActive(false);
                    textDialogue[i + 1].SetActive(true);
                    if (!voiceNpc.isPlaying)
                        voiceNpc.Play();
                    break;
                }
            }
            else
            {
                gameManager.player.SetAnimYesGesture();
                Invoke("InvokeNewPath", 1f);
                gameObject.SetActive(false);
            }
        }
    }

    void InvokeNewPath()
    {
        gameManager.ResetMissionText();
        gameManager.SetMissionRefectory();
        managerLevel.ViewArrowRefactory();
        managerLevel.SetEnterRefactory(true);
        npcCurrent.SelectNewPath();
    }
}