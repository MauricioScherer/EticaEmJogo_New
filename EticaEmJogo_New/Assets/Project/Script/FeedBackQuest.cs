using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackQuest : MonoBehaviour
{
    public GameManager gameManager;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.position = gameManager.feedBackActive.position;
	}
}
