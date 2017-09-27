using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonDialogueBigBoss : MonoBehaviour
{
    public GameObject[] textDialogue;
    public GameObject npc;
    public TextMesh ballon1;
    public TextMesh ballon2;
    public GameObject player;
    public ManagerLevel5 managerLevel5;

    void Start()
    {
        ballon1.text = "Olá " + PlayerPrefs.GetString("nameSelect") + "!" + "\n Você teve uma jornada \n e tanto até em!";

        if(PlayerPrefs.GetInt("pointsSelect") < 39)
        {
            ballon2.text = "balão fala para jogador \n com até 38 pontos";
        }
        else
        {
            ballon2.text = "balão fala para jogador \n com mais de 38 pontos";
        }
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
                    if(i == 2)
                    {
                        player.GetComponent<Animator>().SetBool("Victory", true);
                        Invoke("ResetAnimVictory", 0.5f);
                    }
                    break;
                }
            }
            else
            {
                managerLevel5.ViewCanvasQuest();
                gameObject.SetActive(false);
            }
        }
    }

    void ResetAnimVictory()
    {
        player.GetComponent<Animator>().SetBool("Victory", false);
    }
}
