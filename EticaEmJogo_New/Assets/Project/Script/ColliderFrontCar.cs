using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFrontCar : MonoBehaviour
{
    private bool _stayCarDirection;

    public CarManager carManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Car")
        {
            _stayCarDirection = true;
            carManager.StopCar();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Car")
        {
            _stayCarDirection = false;
            Invoke("ReturnMoveCar", 3);
        }
    }

    void ReturnMoveCar()
    {
        if (!_stayCarDirection)
        {
            carManager.ReturnRoad();
        }
        else
        {
            carManager.StopCar();
        }
    }
}
