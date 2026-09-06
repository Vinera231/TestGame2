using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void Show()
    {
        panel.SetActive(true);
        PauseSwitcher.Instance.Pause();
    }
}
