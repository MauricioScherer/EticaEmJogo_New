using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonDialogueGigBoss2 : MonoBehaviour
{
    public GameObject[] textDialogue;
    public GameObject npc;
    public GameObject player;
    public ManagerLevel5 managerLevel5;

    void Start ()
    {
        player = player.GetComponent<ManagerPlayerLV5>().playerSelect;
    }

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
                    if (i == 0)
                    {
                        player.GetComponent<Animator>().SetBool("Victory", true);
                        Invoke("ResetAnimVictory", 0.5f);
                    }
                    break;
                }
            }
            else
            {
                managerLevel5.LoadLevel();
                gameObject.SetActive(false);
            }
        }
    }

    void ResetAnimVictory()
    {
        player.GetComponent<Animator>().SetBool("Victory", false);
    }
}
