using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform audioListenerPosition;
    public Transform playerPosition;
    public float distanciaEmZ;
    public float speed;

    void Update()
    {
        transform.position = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z - distanciaEmZ);
        audioListenerPosition.position = Vector3.MoveTowards(audioListenerPosition.position, playerPosition.position, speed * Time.deltaTime);

    }
}
