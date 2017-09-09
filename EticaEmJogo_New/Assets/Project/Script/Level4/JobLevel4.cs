using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobLevel4 : MonoBehaviour
{
    private bool _stayDoc;
    private bool _stayMensager;
    private int _numArqTemp;

    public Texture2D pcCursor;
    public Texture2D docCursor;
    public Transform[] doc;    
    public Transform[] docPosition;
    public GameObject[] docOpen;
    public GameObject mensager;    
    public MensagerManager mensagerManager;

    public TriggerFolderDoc triggerDocAproved;
    public TriggerFolderDoc triggerDocReproved;

    void Start ()
    {
        Invoke("ViewNewMensager", 3f);
	}
	
	void Update ()
    {
        if(_stayDoc)
        {
            if(mensagerManager.finalizeMensage1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    docOpen[_numArqTemp].SetActive(true);
                }
                else if (Input.GetMouseButton(1))
                {
                    doc[_numArqTemp].position = Input.mousePosition;
                }
            }
        }
        else if(_stayMensager)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(mensagerManager.GetStayVisibolSimbol())
                {
                    mensagerManager.ViewSimbolNewMensage();
                }
                mensager.SetActive(true);
            }
        }
	}

    public void EnterScreenPc()
    {
        Cursor.SetCursor(pcCursor, Vector2.zero, CursorMode.Auto);
    }
    public void ExitScreenPc()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void EnterMensager()
    {
        _stayMensager = true;
        Cursor.SetCursor(docCursor, Vector2.zero, CursorMode.Auto);
    }
    public void ExitMensager()
    {
        _stayMensager = false;
        Cursor.SetCursor(pcCursor, Vector2.zero, CursorMode.Auto);
    }
    public void CloseMensager()
    {
        mensager.SetActive(false);
    }
    public void ViewNewMensager()
    {
        if(!mensager.activeSelf)
        {
            mensagerManager.ViewSimbolNewMensage();
            mensagerManager.ViewMensages();
        }
        else
        {
            mensagerManager.ViewMensages();
        }
    }

    public void EnterDoc(int p_numDoc)
    {
        _numArqTemp = p_numDoc;
        _stayDoc = true;        
        Cursor.SetCursor(docCursor, Vector2.zero, CursorMode.Auto);
    }
    public void ExitDoc()
    {
        _stayDoc = false;
        Cursor.SetCursor(pcCursor, Vector2.zero, CursorMode.Auto);
    }
    public void CloseArqDoc()
    {
        for (int i = 0; i < docOpen.Length; i++)
        {
            if (docOpen[i].activeSelf)
                docOpen[i].SetActive(false);
        }
        ExitDoc();
    }
    
    public void GetOutDocument(int p_num)
    {        
        if(triggerDocAproved.GetDocStayFolder())
        {
            triggerDocAproved.DeactiveDoc();
        }
        else if(triggerDocReproved.GetDocStayFolder())
        {
            triggerDocReproved.DeactiveDoc();
        }

        if (doc[p_num].localPosition.x > 450 || doc[p_num].localPosition.x < -510 ||
            doc[p_num].localPosition.y > 250 || doc[p_num].localPosition.y < -230)
        {
            doc[p_num].position = docPosition[p_num].position;
        }
    }
}
