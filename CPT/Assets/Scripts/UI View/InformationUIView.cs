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


    public void HideAllElements()
    {
        _elements.SetActive(false);
    }

    public void ShowAllElements()
    {
        _elements.SetActive(true);
        SetupButton();
    }

    private void Awake()
    {
        HideAllElements();
    }

    private void SetupButton()
    {
        _saveButton.onClick.RemoveAllListeners();
        _saveButton.onClick.AddListener(OnSaveClicked);
    }

    private void OnSaveClicked()
    {
        SaveClicked?.Invoke();
        _inputManager.ResetInputFields();
    }
}
