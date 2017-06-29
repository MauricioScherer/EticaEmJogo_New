using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonDialogueStatic : MonoBehaviour
{
    public GameObject[] textDialogue;
    public GameObject npc;
    public NpcDialogue1 npcDial1;

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
                npcDial1.isMove = true;
                npcDial1.SelectNewPath();
                gameObject.SetActive(false);
            }
        }
    }
}
