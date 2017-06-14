using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition;
    public float speed;

    void Awake()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraPosition.rotation;
    }
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPosition.position, speed * Time.deltaTime);
	}
}
