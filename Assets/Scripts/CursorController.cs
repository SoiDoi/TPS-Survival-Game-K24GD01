using UnityEngine;

public class CursorController : MonoBehaviour
{
    //void Start()
    //{
    //    // Ẩn chuột
    //    Cursor.visible = false;

    //    // Khóa chuột ở giữa màn hình
    //    Cursor.lockState = CursorLockMode.Locked;

    //    // Nếu chỉ muốn ẩn nhưng vẫn cho di chuyển tự do:
    //    // Cursor.lockState = CursorLockMode.None;
    //}

    //void Update()
    //{
    //    // Nhấn ESC để hiện lại chuột (debug tiện lợi)
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        Cursor.visible = true;
    //        Cursor.lockState = CursorLockMode.None;
    //    }
    //}

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

    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
