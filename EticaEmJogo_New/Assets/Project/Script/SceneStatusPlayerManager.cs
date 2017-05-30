using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStatusPlayerManager : MonoBehaviour
{
    private string _numberCpf;
    private int _numberAvatar;

    public PersonManager personManager;

    public Text cpfPlayer;
    public Text namePlayer;
    public Text scorePlayer;
    public Text[] quest;
    public GameObject poolAvatar;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void SetStatus(string p_cpf, string p_name, int p_score, int p_avatar)
    {
        _numberCpf = p_cpf;
        _numberAvatar = p_avatar;
        cpfPlayer.text = "CPF: " + p_cpf;
        namePlayer.text = p_name;
        scorePlayer.text = "Pontuação: " + p_score.ToString();
        poolAvatar.SetActive(true);
        poolAvatar.GetComponent<PoolPerson>().ActivateViewAvatar(p_avatar);
    }

    public void BackScreen()
    {
        poolAvatar.GetComponent<PoolPerson>().ResetPool();
        poolAvatar.SetActive(false);
        personManager.ReturnAdminScreen();
    }

    public void DeletePerfil()
    {        
        personManager.DeletePerfilArray(_numberCpf);
        BackScreen();
    }
}
