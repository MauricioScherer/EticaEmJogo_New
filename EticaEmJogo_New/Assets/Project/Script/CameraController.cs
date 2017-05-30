using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition;
    public float speed;
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPosition.position, speed * Time.deltaTime);
	}
}
