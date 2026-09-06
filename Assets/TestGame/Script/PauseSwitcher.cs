using System;
using UnityEngine;

public class PauseSwitcher : MonoBehaviour
{
    private int _counter = 0;

    public event Action Paused;
    public event Action Continued;

    public static PauseSwitcher Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(Instance);
            return;
        }

        Destroy(this);
    }

    public void Continue()
    {
        _counter--;
        HandleChanged();
    }

    public void Pause()
    {
        _counter++;
        HandleChanged();
    }

    private void HandleChanged()
    {
        if (_counter <= 0)
        {
            Time.timeScale = 1;
            Continued?.Invoke();
        }
        else
        {
            Time.timeScale = 0;
            Paused?.Invoke();
        }
    }
}