
using System;
using UnityEngine;
using UnityEngine.UI;

public class OverviewUIView : MonoBehaviour
{
    [SerializeField] private GameObject _elements;
    [SerializeField] private Button _button;

    public event Action ScreenTapped;

    public void ShowAllElements()
    {
        _elements.SetActive(true);
    }

    public void HideAllElements()
    {
        _elements.SetActive(false);
    }

    private void Awake()
    {
        SetupButton();
        HideAllElements();
    }

    private void SetupButton()
    {
        _button.onClick.AddListener(OnScreenTapped);
    }

    private void OnScreenTapped()
    {
        ScreenTapped?.Invoke();
    }
}
