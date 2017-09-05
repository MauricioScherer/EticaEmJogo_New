using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobLevel4 : MonoBehaviour
{
    public bool _stayScreenPc;
    public bool _stayDoc;
    public bool _getDocument;
    public bool _docOpenActive;
    public int _numArqTemp;

    public Texture2D pcCursor;
    public Texture2D docCursor;
    public Transform[] doc;    
    public Transform[] docPosition;
    public GameObject[] docOpen;

    public TriggerFolderDoc triggerDocAproved;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(_stayDoc)
        {
            if(Input.GetMouseButtonDown(1))
            {
                docOpen[_numArqTemp].SetActive(true);
                _docOpenActive = true;
            }
            else if(Input.GetMouseButton(0))
            {
                doc[_numArqTemp].position = Input.mousePosition;
            }
        }
	}

    public void EnterScreenPc()
    {
        _stayScreenPc = true;
        Cursor.SetCursor(pcCursor, Vector2.zero, CursorMode.Auto);
    }
    public void ExitScreenPc()
    {
        _stayScreenPc = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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
        _docOpenActive = false;
    }
    
    public void GetOutDocument(int p_num)
    {        
        if(triggerDocAproved.GetDocStayFolder())
        {
            triggerDocAproved.DeactiveDoc();
        }
        if (doc[p_num].localPosition.x > 450 || doc[p_num].localPosition.x < -510 ||
            doc[p_num].localPosition.y > 250 || doc[p_num].localPosition.y < -230)
        {
            doc[p_num].position = docPosition[p_num].position;
        }
        _getDocument = false;
    }
}
