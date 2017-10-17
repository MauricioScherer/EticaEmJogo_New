using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStatusPlayerManager : MonoBehaviour
{
    private string _numberCpf;
    private int _numberPag;
    public int[] _questSelectLocal;

    public PersonManager personManager;

    public Text cpfPlayer;
    public Text namePlayer;
    public Text scorePlayer;
    public Text answerPlayer;
    public Text numberPagStr;
    public GameObject alertDelete;
    public GameObject buttonNext;
    public GameObject buttonBack;
    public GameObject[] pag;
    public GameObject[] selectQuest1;
    public GameObject[] selectQuest2;

    public void Start()
    {

    }

    public void SetStatus(string p_cpf, string p_name, int p_score, string p_answer)
    {
        _numberCpf = p_cpf;
        cpfPlayer.text = p_cpf;
        namePlayer.text = p_name;
        scorePlayer.text = p_score.ToString() + " / 65";
        answerPlayer.text = p_answer;
        _questSelectLocal = PlayerPrefsUtility.GetIntArray(p_cpf);
        ResetStatusPag();
        ViewQuestSelect();
    }

    void ViewQuestSelect()
    {
        for(int i = 0; i < pag.Length; i++)
        {
            if(pag[i].activeSelf)
            {
                if(_questSelectLocal[i + 1] != 99)
                {
                    selectQuest1[_questSelectLocal[i + i]].SetActive(true);
                }
                if (i < 6)
                {
                    if (_questSelectLocal[i + i + 1] != 99)
                    {
                        selectQuest2[_questSelectLocal[i + i + 1]].SetActive(true);
                    }
                }
                break;
            }
        }
    }

    void ResetQuestSelect()
    {
        for(int i = 0; i < selectQuest1.Length; i++)
        {
            selectQuest1[i].SetActive(false);
            selectQuest2[i].SetActive(false);
        }
    }

    public void BackScreen()
    {
        ResetStatusPag();
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

    public void NextPag()
    {
        for(int i = 0; i < pag.Length; i++)
        {
            if(pag[i].activeSelf)
            {
                _numberPag++;
                numberPagStr.text = "Página " + _numberPag.ToString() + "/7";
                if (!buttonBack.activeSelf)
                {
                    buttonBack.SetActive(true);
                }
                if (_numberPag == pag.Length)
                {
                    buttonNext.SetActive(false);
                }
                pag[i].SetActive(false);
                pag[i + 1].SetActive(true);
                ResetQuestSelect();
                ViewQuestSelect();
                break;
            }
        }
    }
    public void BackPag()
    {
        for (int i = 0; i < pag.Length; i++)
        {
            if (pag[i].activeSelf)
            {
                _numberPag--;
                numberPagStr.text = "Página " + _numberPag.ToString() + "/7";
                if (!buttonNext.activeSelf)
                {
                    buttonNext.SetActive(true);
                }
                if (_numberPag == 1)
                {
                    buttonBack.SetActive(false);
                }
                pag[i].SetActive(false);
                pag[i - 1].SetActive(true);
                ResetQuestSelect();
                ViewQuestSelect();
                break;
            }
        }
    }

    void ResetStatusPag()
    {
        _numberPag = 1;
        numberPagStr.text = "Página " + _numberPag.ToString() + "/7";
        pag[0].SetActive(true);
        ResetQuestSelect();
        for (int i = 1; i < pag.Length; i++)
        {
            pag[i].SetActive(false);
        }
        if (buttonBack.activeSelf)
        {
            buttonBack.SetActive(false);
        }
        if (!buttonNext.activeSelf)
        {
            buttonNext.SetActive(true);
        }
    }
}
