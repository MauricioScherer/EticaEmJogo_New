using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneAdminManager : MonoBehaviour
{
    private int _numberPage;
    private int _tempCount;

    public PersonManager personManager;
    public Text numberPageText;
    public Text[] names;
    public GameObject[] avatar;
    public GameObject[] buttonSlot;    

	void Start ()
    {
        Initialize();
    }
	
	void Update ()
    {

    }

    public void Initialize()
    {
        _numberPage = 1;
        _tempCount = 0;
        numberPageText.text = "Pagina: " + _numberPage + "/" + (personManager.cpfplayerArray.Length / name.Length);
        ResetSlot();
        SetSlot();
    }

    void ResetSlot()
    {
        for (int i = 0; i < name.Length; i++)
        {
            avatar[i].GetComponent<PoolPerson>().ResetPool();
        }
    }

    public void NextPage()
    {
        if(_numberPage < personManager.cpfplayerArray.Length / name.Length)
        {
            _numberPage += 1;
            _tempCount += 10;
            numberPageText.text = "Pagina: " + _numberPage + "/" + (personManager.cpfplayerArray.Length / name.Length);
            ResetSlot();
            SetSlot();
        }
    }

    public void BackPage()
    {
        if(_numberPage > 1)
        {
            _numberPage -= 1;
            _tempCount -= 10;
            numberPageText.text = "Pagina: " + _numberPage + "/" + (personManager.cpfplayerArray.Length / name.Length);
            ResetSlot();
            SetSlot();
        }
    }

    public void SetSlot()
    {
        for (int i = 0; i < names.Length; i++)
        {          
            if (personManager.cpfplayerArray[i + _tempCount] != "0")
            {
                names[i].text = personManager.nameplayerArray[i + _tempCount];
                buttonSlot[i].SetActive(true);
                avatar[i].SetActive(true);
                int __numAvatar = personManager.avatarPlayerArray[i + _tempCount];
                avatar[i].GetComponent<PoolPerson>().ActivateViewAvatar(__numAvatar);
            }
            else
            {
                names[i].text = "Vazio";
                buttonSlot[i].SetActive(false);                
                avatar[i].SetActive(false);
            }
        }
    }

    public void SelectSlotPlayer(int p_NumberSlot)
    {
        personManager.SelectStatusPlayer(p_NumberSlot + _tempCount);
    }
}
