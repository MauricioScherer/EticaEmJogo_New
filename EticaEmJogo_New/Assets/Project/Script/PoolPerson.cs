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

    public int GetAvatarSelect()
    {
        return avatarNumberSelect;
    }

    public void SetAvatarSelect(int p_num)
    {
        avatarNumberSelect = p_num;
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

    public void ViewMask(GameObject p_mask)
    {
        p_mask.SetActive(true);
    }
    public void NoViewMask(GameObject p_mask)
    {
        p_mask.SetActive(false);
    }
}
