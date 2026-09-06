using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private ButtonInformer _button;

    private void OnEnable() =>
        _button.Clicked += QuiteGame;

    private void OnDisable() =>   
        _button.Clicked -= QuiteGame;

    public void QuiteGame() =>
    Application.Quit();
}