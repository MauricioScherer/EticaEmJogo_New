using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private Transform _currentPosition;
    private Transform _targetPosition;
    private bool road;

    public float speed;
    public Transform[] position1;
    public Transform[] position2;
	
	void Update ()
    {
        if (road)
        {
            float step = speed * Time.deltaTime;
            float dist = Vector3.Distance(_targetPosition.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, step);

            if (dist <= 0.5)
            {                
                gameObject.SetActive(false);
                road = false;
            }
        }
	}

    public void initialize()
    {
        int pos = Random.Range(1, 3);

        if(pos == 1)
        {
            transform.position = position1[0].position;
            transform.rotation = position1[0].rotation;
            _currentPosition = position1[0];
            _targetPosition = position1[1];
        }
        else if (pos == 2)
        {
            transform.position = position2[0].position;
            transform.rotation = position2[0].rotation;
            _currentPosition = position2[0];
            _targetPosition = position2[1];
        }
        road = true;
    }

    public void StopCar()
    {
        if (road)        
            road = false;        
    }

    public void ReturnRoad()
    {
        if(!road)
            road = true;
    }

}
