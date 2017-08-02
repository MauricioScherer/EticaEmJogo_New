using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPosition : MonoBehaviour
{
    private float timeInvert;
    private bool down;

    public float speed;
    public Transform arrow;
    public Transform positionUp;
    public Transform positionDown;

	void Start ()
    {
        down = true;
    }
	
	void Update ()
    {
        timeInvert += 1 * Time.deltaTime;

        if(timeInvert >= 2 && down)
        {
            down = false;
        }
        else if(timeInvert >= 4)
        {
            timeInvert = 0;
            down = true;
        }
        
        if(down)
            arrow.position = Vector3.MoveTowards(arrow.position, positionDown.position, speed * Time.deltaTime);
        else
            arrow.position = Vector3.MoveTowards(arrow.position, positionUp.position, speed * Time.deltaTime);
    }
}
