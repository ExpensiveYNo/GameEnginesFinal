using UnityEngine;

public class CursorFix : MonoBehaviour
{
    public void UnlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}