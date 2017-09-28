using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerAnimFinalLevel : MonoBehaviour
{
    private bool _fadeMusic;

    public Transform cameraPosition;
    public Transform lightScene;
    public Transform lightPositionPart4;
    public Animator cameraAnim;
    public GameObject animPart1;
    public GameObject animPart2;
    public GameObject animPart3;
    public GameObject animPart4;
    public GameObject logo;
    public GameObject feedGod;
    public GameObject feedBad;
    public SelectPlayerStandard playerSelectStandard;
    public GameObject playerSelect;
    public Transform positionPlayerPart4;
    public GameObject fadeEnd;
    public AudioSource music;

    public Transform positionCamera2;
    public Transform positionCamera3;
    public Transform positionCamera4;

    public GameObject fade;
    public GameObject fadeIn;
    public float timeActiveFade1;
    public float timeDeactiveFade;
    public float timeActiveFade2;
    public float timeActiveFade3;
    public float timeActiveFade4;

    void Start ()
    {
        if(PlayerPrefs.GetInt("pointsSelect") >= 39)
        {
            animPart1.SetActive(true);
            Invoke("ActiveFade", timeActiveFade1);
        }
        else
        {
            ActivePart4();
        }
        fadeIn.SetActive(true);
    }
	
	void Update ()
    {
		if(_fadeMusic)
        {
            music.volume -= 0.015f * Time.deltaTime;

            if(music.volume <= 0)
            {
                LoadMenu();
                _fadeMusic = false;
            }
        }
	}

    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void ActiveFade()
    {
        fade.SetActive(true);
        Invoke("DeactiveFade", timeDeactiveFade);
        if (animPart1.activeSelf)
        {            
            Invoke("ActivePart2", timeDeactiveFade / 2);
        }
        else if(animPart2.activeSelf)
        {
            Invoke("ActivePart3", timeDeactiveFade / 2);
        }
        else if (animPart3.activeSelf)
        {
            Invoke("ActivePart4", timeDeactiveFade / 2);
        }
    }

    void DeactiveFade()
    {
        fade.SetActive(false);
    }

    void ActivePart2()
    {
        cameraPosition.position = positionCamera2.position;
        cameraAnim.SetBool("Cam2", true);
        animPart1.SetActive(false);
        animPart2.SetActive(true);
        Invoke("ActiveFade", timeActiveFade2);
    }

    void ActivePart3()
    {
        cameraPosition.position = positionCamera3.position;
        cameraAnim.SetBool("Cam3", true);
        animPart2.SetActive(false);
        animPart3.SetActive(true);
        Invoke("ActiveFade", timeActiveFade3);
    }

    void ActivePart4()
    {
        cameraPosition.position = positionCamera4.position;
        lightScene.position = lightPositionPart4.position;
        lightScene.eulerAngles = lightPositionPart4.eulerAngles;
        cameraAnim.SetBool("Cam4", true);
        animPart3.SetActive(false);
        animPart4.SetActive(true);
        Invoke("ActiveTextEnd", timeActiveFade4);
    }

    void ActiveTextEnd()
    {
        logo.SetActive(true);
        if(PlayerPrefs.GetInt("pointsSelect") >= 39)
        {
            feedGod.SetActive(true);
        }
        else
        {
            feedBad.SetActive(true);
        }
        Invoke("SetPlayer", 45f);
    }

    void SetPlayer()
    {
        playerSelect = playerSelectStandard.playerSelect;
        playerSelect.GetComponent<MovePlayerStandard>().finalCutScene = true;
        playerSelect.transform.eulerAngles = positionPlayerPart4.eulerAngles;
        Invoke("SetAnimPLayer", 14f);
    }

    void SetAnimPLayer()
    {
        playerSelect.GetComponent<Animator>().SetBool("Wave", true);
        Invoke("viewFadeEnd", 3f);
    }

    void viewFadeEnd()
    {
        fadeEnd.SetActive(true);
        _fadeMusic = true;
    }
}
