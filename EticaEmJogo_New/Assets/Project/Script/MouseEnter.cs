using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnter : MonoBehaviour
{
    public Texture2D eyeCursor;
    public ManagerLevel managerLevel;
    public ManagerLevel2 managerLevel2;

    void OnMouseEnter()
    {
        Cursor.SetCursor(eyeCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
