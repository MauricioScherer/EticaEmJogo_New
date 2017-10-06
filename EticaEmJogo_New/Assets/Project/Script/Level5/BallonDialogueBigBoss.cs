using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonDialogueBigBoss : MonoBehaviour
{
    public GameObject[] textDialogue;
    public GameObject npc;
    public TextMesh ballon1;
    public ManagerLevel5 managerLevel5;

    void Start()
    {
        ballon1.text = "Olá " + PlayerPrefs.GetString("nameSelect") + "." + "\n Sou o Bernardo, \n gestor de RH.";
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
                    break;
                }
            }
            else
            {
                managerLevel5.ViewCanvasQuest(true);
                gameObject.SetActive(false);
            }
        }
    }
}
