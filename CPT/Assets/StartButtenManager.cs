using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButtenManager : MonoBehaviour
{
    [SerializeField]
    private Button _StartButton;
    [SerializeField]
    private GameObject _CharacteristicsPanel;

    private void Awake()
    {
        if (_CharacteristicsPanel != null)
        {
            _CharacteristicsPanel.SetActive(false); 
        }
        else
        {
            Debug.LogError("Characteristics Panel is not assigned in the Inspector.");
        }
    }

    private void Start()
    {
        if (_StartButton != null)
        {
            _StartButton.onClick.AddListener(OnStartButtonClicked);
        }
        else
        {
            Debug.LogError("Start Button is not assigned in the Inspector.");
        }
    }

    private void OnStartButtonClicked()
    {
        Debug.LogError("Start Button clicked!");

        _StartButton.gameObject.SetActive(false);

        if (_CharacteristicsPanel != null)
        {
            _CharacteristicsPanel.SetActive(true); 
        }
    }
}