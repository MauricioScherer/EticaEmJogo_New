using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFolderDoc : MonoBehaviour
{
    private bool _stayDocInFolder;
    private GameObject doc;
    private int count;

    public JobLevel4 job;
    public Job2Level4 job2;
    public Text countFolder;    

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
            count++;
            countFolder.text = count.ToString();
            _stayDocInFolder = false;
            if(job)
                job.CloseArqDoc();
            else if(job2)
                job2.CloseArqDoc();
            doc.SetActive(false);
            if(job)
                job.mensagerManager.CountNewMensage2();
            else if(job2)
                job2.mensagerManager.CountNewMensage1();
        }
    }

    public bool GetDocStayFolder()
    {
        return _stayDocInFolder;
    }
}
