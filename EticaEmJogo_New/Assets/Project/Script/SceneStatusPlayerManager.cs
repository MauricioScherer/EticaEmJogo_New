using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStatusPlayerManager : MonoBehaviour
{
    private string _numberCpf;

    public PersonManager personManager;

    public Text cpfPlayer;
    public Text namePlayer;
    public Text scorePlayer;
    public GameObject alertDelete;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void SetStatus(string p_cpf, string p_name, int p_score)
    {
        _numberCpf = p_cpf;
        cpfPlayer.text = p_cpf;
        namePlayer.text = p_name;
        scorePlayer.text = p_score.ToString() + " / 65";
    }

    public void BackScreen()
    {
        personManager.ReturnAdminScreen();
    }

    public void ViewAlertDelete(bool p_state)
    {
        alertDelete.SetActive(p_state);
    }

    public void DeletePerfil()
    {        
        personManager.DeletePerfilArray(_numberCpf);
        BackScreen();
    }
}
