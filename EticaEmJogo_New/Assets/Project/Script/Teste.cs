using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
	void Start ()
    {

    }
	
	void Update ()
    {

	}

    public void OnBecameInvisible()
    {
        Debug.Log("'" + name + "' can *not* be seen anymore.");
    }

    public void OnBecameVisible()
    {
        Debug.Log("'" + name + "' can be seen now.");
    }
}
