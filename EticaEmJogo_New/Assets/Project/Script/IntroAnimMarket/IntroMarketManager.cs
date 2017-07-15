using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMarketManager : MonoBehaviour
{
    public GameObject[] poolAvatar;
    public IntroMovePlayer player;
    public AudioSource music;

    void Awake()
    {
        if (Time.deltaTime < 1)
            Time.timeScale = 1;
    }

    public void StartAvatar()
    {
        if (PlayerPrefs.HasKey("avatarSelect"))
        {
            int __tempNumberPool = PlayerPrefs.GetInt("avatarSelect");
            poolAvatar[__tempNumberPool].SetActive(true);
            player = poolAvatar[__tempNumberPool].GetComponent<IntroMovePlayer>();
        }
        else
        {
            poolAvatar[0].SetActive(true);
            player = poolAvatar[0].GetComponent<IntroMovePlayer>();
        }
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene("Scene_02");
    }
}
