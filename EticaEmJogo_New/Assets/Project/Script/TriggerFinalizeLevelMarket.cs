using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalizeLevelMarket : MonoBehaviour
{
    private bool _viewArrow;

    public ManagerLevel2 managerLevel2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (managerLevel2.numClientFinalize == 3 && !_viewArrow)
            {
                managerLevel2.ViewArrowEstoque();

                //TODO
                //obsoleto
                //managerLevel2.FadeIn();

                managerLevel2.FadeMusic();
                managerLevel2.ViewPlacarFinalLevel(true);
                gameObject.SetActive(false);
                _viewArrow = true;
            }
        }
    }
}
