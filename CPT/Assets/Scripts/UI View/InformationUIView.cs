using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUIView : MonoBehaviour
{
    [SerializeField] private GameObject _elements;
    [SerializeField] private Button _button;

    [SerializeField] private InputManager _inputManager;

    public InputManager InputManager => _inputManager;

    public event Action ScreenTapped;


    public void HideAllElements()
    {
        _elements.SetActive(false);
    }

    public void ShowAllElements()
    {
        _elements.SetActive(true);
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

    // Input manager reference
}
