using UnityEngine;

public class CursorController : MonoBehaviour
{
    private void Start()
    {
        HideCursor();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            // Khi click lại vào game, ẩn và khóa chuột
            HideCursor();
        }
        else
        {
            // Khi mất focus (alt+tab), hiện chuột ra
            ShowCursor();
        }
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
