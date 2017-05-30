using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPerson : MonoBehaviour
{
    public GameObject[] avatar;
    public int avatarNumberSelect;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void NextAvatar()
    {
        for (int i=0; i < avatar.Length; i++)
        {
            if(avatar[i].activeSelf)
            {
                avatar[i].SetActive(false);
                if (i != avatar.Length - 1)
                {
                    avatarNumberSelect++;
                    avatar[i + 1].SetActive(true);
                }
                else
                {
                    avatarNumberSelect = 0;
                    avatar[0].SetActive(true);
                }
                break;
            }
        }
    }

    public void BackAvatar()
    {
        for (int i = 0; i < avatar.Length; i++)
        {
            if (avatar[i].activeSelf)
            {
                avatar[i].SetActive(false);
                if (i != 0)
                {
                    avatarNumberSelect--;
                    avatar[i - 1].SetActive(true);
                }
                else
                {
                    avatarNumberSelect = avatar.Length - 1;
                    avatar[avatar.Length - 1].SetActive(true);
                }
                break;
            }
        }
    }

    public int GetAvatarSelect()
    {
        return avatarNumberSelect;
    }

    public void ActivateViewAvatar(int p_numAvatar)
    {
        avatar[p_numAvatar].SetActive(true);
    }

    public void DesactiveViewAvatar(int p_numAvatar)
    {
        avatar[p_numAvatar].SetActive(false);
    }

    public void ResetPool()
    {
        for(int i=0; i<avatar.Length; i++)
        {
            avatar[i].SetActive(false);
        }
    }

    public void StandardPool()
    {
        avatar[0].SetActive(true);
    }
}
