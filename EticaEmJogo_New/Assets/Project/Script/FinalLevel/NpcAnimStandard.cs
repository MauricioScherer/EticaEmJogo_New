using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimStandard : MonoBehaviour
{
    private Animator _anim;

    void Start ()
    {
        _anim = GetComponent<Animator>();
        int __temp = Random.Range(0, 4);

        if (__temp == 0)
            SelectAnim();
        else if (__temp == 1)
            Invoke("SelectAnim", 0.4f);
        else if (__temp == 2)
            Invoke("SelectAnim", 0.8f);
        else if (__temp == 3)
            Invoke("SelectAnim", 1.2f);
    }

    void SelectAnim()
    {
        int __temp = Random.Range(0,3);

        if(__temp == 0)
        {
            _anim.SetBool("Victory", true);
        }
        else if (__temp == 1)
        {
            _anim.SetBool("YesGesture", true);
        }
        else
        {
            _anim.SetBool("Wave", true);
        }
        Invoke("ResetAnim", 0.5f);
    }

    void ResetAnim()
    {
        _anim.SetBool("Victory", false);
        _anim.SetBool("YesGesture", false);
        _anim.SetBool("Wave", false);
        SelectAnim();
    }
}
