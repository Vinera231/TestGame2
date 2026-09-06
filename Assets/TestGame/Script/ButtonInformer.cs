using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonInformer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button _button;

    public event Action Clicked;
    public event Action Entered;
    public event Action Exited;

    private void OnEnable() =>
        _button.onClick.AddListener(OnClick);

    private void OnDisable() =>
       _button.onClick.RemoveListener(OnClick);

    private void OnClick() =>
       Clicked?.Invoke();


    public void OnPointerEnter(PointerEventData eventData) =>
        Entered?.Invoke();

    public void OnPointerExit(PointerEventData eventData) =>
        Exited?.Invoke();
}
