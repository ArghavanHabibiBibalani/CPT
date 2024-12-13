using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUIView : MonoBehaviour
{
    [SerializeField] private GameObject _elements;
    [SerializeField] private Button _saveButton;

    [SerializeField] private PersonalInfoInputManager _inputManager;

    public PersonalInfoInputManager InputManager => _inputManager;

    public event Action SaveClicked;

    private void Awake()
    {
        SetupButton();
        HideAllElements();
    }

    public void HideAllElements()
    {
        _elements.SetActive(false);
    }

    public void ShowAllElements()
    {
        _elements.SetActive(true);
        _saveButton.onClick.AddListener(OnSaveClicked);
    }

    public void ResetElements()
    {
        _inputManager.Reset();
        _saveButton.onClick.RemoveAllListeners();
    }

    private void SetupButton()
    {
        _saveButton.onClick.AddListener(OnSaveClicked);
    }

    private void OnSaveClicked()
    {
        SaveClicked?.Invoke();
    }
}
