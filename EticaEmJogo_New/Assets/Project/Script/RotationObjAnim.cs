using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjAnim : MonoBehaviour
{
    public float speed;

    void FixedUpdate ()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
