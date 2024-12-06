
using System;
using UnityEngine;
using UnityEngine.UI;

public class OverviewUIView : MonoBehaviour
{
    [SerializeField] private GameObject _overviewPanel;
    [SerializeField] private Button _button;

    public event Action ScreenTapped;

    public void ShowOverviewPanel()
    {
        _overviewPanel.SetActive(true);
    }

    public void HideOverviewPanel()
    {
        _overviewPanel.SetActive(false);
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
