using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFolderDoc : MonoBehaviour
{
    private bool _stayDocInFolder;
    private GameObject doc;

    public JobLevel4 job;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Doc"))
        {
            _stayDocInFolder = true;
            doc = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Doc"))
        {
            _stayDocInFolder = false;
            doc = null;
        }
    }

    public void DeactiveDoc()
    {
        if(_stayDocInFolder)
        {
            _stayDocInFolder = false;
            job.CloseArqDoc();
            doc.SetActive(false);
        }
    }

    public bool GetDocStayFolder()
    {
        return _stayDocInFolder;
    }
}
