using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerStandard : MonoBehaviour
{
    public GameObject[] poolAvatar;
    public GameObject playerSelect;

    void Awake()
    {
        if (Time.deltaTime < 1)
            Time.timeScale = 1;
        StartAvatar();

    }

    public void StartAvatar()
    {
        if (PlayerPrefs.HasKey("avatarSelect"))
        {
            int __tempNumberPool = PlayerPrefs.GetInt("avatarSelect");
            poolAvatar[__tempNumberPool].SetActive(true);
            playerSelect = poolAvatar[__tempNumberPool];
        }
        else
        {
            poolAvatar[0].SetActive(true);
            playerSelect = poolAvatar[0];
        }
    }
}
