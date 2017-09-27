using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerStandard : MonoBehaviour
{
    public GameObject[] poolAvatar;

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
        }
        else
        {
            poolAvatar[0].SetActive(true);
        }
    }
}
