using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBusCollider : MonoBehaviour
{
    private bool avatarInitialize;

    public IntroMarketManager manager;

	void OnTriggerEnter(Collider other)
    {
        if(!avatarInitialize)
        {
            manager.StartAvatar();
            avatarInitialize = true;
        }        
    }
}
