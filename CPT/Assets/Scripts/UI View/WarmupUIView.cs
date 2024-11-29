
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarmupUIView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _topSquare;
    [SerializeField] private Image _bottomSquare;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private Image _startImage;

    public event Action ScreenTapped;

    private void Awake()
    {
        SetUpButton();
    }

    public void HideAllElements()
    {
        _button.gameObject.SetActive(false);
        _topSquare.gameObject.SetActive(false);
        _bottomSquare.gameObject.SetActive(false);
        _countdownText.gameObject.SetActive(false);
        _startImage.gameObject.SetActive(false);
    }

    public void UnhideAllElements()
    {
        _button.gameObject.SetActive(true);
        _topSquare.gameObject.SetActive(true);
        _bottomSquare.gameObject.SetActive(true);
        _countdownText.gameObject.SetActive(true);
        _startImage.gameObject.SetActive(true);
    }

    public void BeginCountdown(float duration)
    {
        _countdownText.gameObject.SetActive(true);
        StartCoroutine(Countdown(duration));
    }

    private IEnumerator Countdown(float duration)
    {
        var timer = duration;
        while (duration > 0)
        {
            _countdownText.text = timer.ToString();
            yield return new WaitForSeconds(1);
            timer--;
        }
        _countdownText.gameObject.SetActive(false);
        _startImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        _startImage.gameObject.SetActive(false);
    }

    private void SetUpButton()
    {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(OnButtonTapped);
    }

    private void OnButtonTapped()
    {
        ScreenTapped?.Invoke();
    }
}
