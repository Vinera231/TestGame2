using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;

    private void OnEnable() =>
        _informer.Clicked += OnResetGame;

    private void OnDisable() =>
        _informer.Clicked -= OnResetGame;

    private void OnResetGame()
    {
        CursorShower.Instance.ShowCursor();
        PauseSwitcher.Instance.Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
