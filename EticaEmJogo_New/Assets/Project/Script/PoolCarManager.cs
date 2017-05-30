using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCarManager : MonoBehaviour
{
    public GameObject[] car;

    void Start()
    {
        SelectNextCar();
    }

	void Update ()
    {

	}
    
    void selectCar()
    {
        int select = Random.Range(0, 12);
        if (!car[select].activeSelf)
        {
            car[select].SetActive(true);
            car[select].GetComponent<CarManager>().initialize();
        }
        SelectNextCar();
    }

    void SelectNextCar()
    {
        int time = Random.Range(2, 8);
        Invoke("selectCar", time);
    }
}
