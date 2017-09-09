using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAlberto : MonoBehaviour
{
    public ManagerLevel4 managerLevel;
    public GameObject[] textDialogue;
    public GameObject npc;

    public void NextDialogue()
    {
        for (int i = 0; i < textDialogue.Length; i++)
        {
            if (i < textDialogue.Length - 1)
            {
                if (textDialogue[i].activeSelf)
                {
                    textDialogue[i].SetActive(false);
                    textDialogue[i + 1].SetActive(true);
                    if (!npc.GetComponent<AudioSource>().isPlaying)
                        npc.GetComponent<AudioSource>().Play();
                    break;
                }
            }
            else
            {
                managerLevel.gameManager.SelectQuest(10);
                gameObject.SetActive(false);
            }
        }
    }
}
