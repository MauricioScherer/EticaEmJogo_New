using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnter : MonoBehaviour
{
    public Texture2D eyeCursor;
    public GameManager gameManager;

    void OnMouseEnter()
    {
        if(gameManager.GetNumberScene() == 5)
        {
            if(!gameManager.managerLevel4.canvasJob.activeSelf && !gameManager.managerLevel4.canvasJob2.activeSelf)
            {
                Cursor.SetCursor(eyeCursor, Vector2.zero, CursorMode.Auto);
            }
        }
        else if(gameManager.GetNumberScene() == 4)
        {
            if(!gameManager.managerLevel3.canvasJob1.activeSelf && !gameManager.managerLevel3.canvasJob2.activeSelf)
            {
                Cursor.SetCursor(eyeCursor, Vector2.zero, CursorMode.Auto);
            }
        }
        else if (gameManager.GetNumberScene() == 3)
        {
            if (!gameManager.managerLevel2.canvasMarket.activeSelf)
            {
                Cursor.SetCursor(eyeCursor, Vector2.zero, CursorMode.Auto);
            }
        }
    }

    void OnMouseExit()
    {
        if (gameManager.GetNumberScene() == 5)
        {
            if (!gameManager.managerLevel4.canvasJob.activeSelf && !gameManager.managerLevel4.canvasJob2.activeSelf)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
        else if (gameManager.GetNumberScene() == 4)
        {
            if (!gameManager.managerLevel3.canvasJob1.activeSelf && !gameManager.managerLevel3.canvasJob2.activeSelf)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
        else if (gameManager.GetNumberScene() == 3)
        {
            if (!gameManager.managerLevel2.canvasMarket.activeSelf)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
    }
}
