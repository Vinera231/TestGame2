using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Show()
    {
        _panel.SetActive(true);
        PauseSwitcher.Instance.Pause();
    }
}