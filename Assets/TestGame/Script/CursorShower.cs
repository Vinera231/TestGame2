using UnityEngine;

public class CursorShower : MonoBehaviour
{
    private static CursorShower s_instance;

    public int _count = 0;
    public static bool Destroyed;
    public static CursorShower Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = FindFirstObjectByType<CursorShower>();
                s_instance.transform.SetParent(null);
                DontDestroyOnLoad(s_instance.gameObject);
            }

            return s_instance;
        }
    }

    private void OnDestroy()
    {
        if (s_instance == this)
            Destroyed = true;
    }

    public void ShowCursor()
    {
        _count--;
        OnHandlChanged();
    }

    public void HideCursor()
    {
        _count++;
        OnHandlChanged();
    }

    private void OnHandlChanged()
    {
        if (_count <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}