
using StatePattern;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestUIView : MonoBehaviour
{
    [SerializeField] private GameObject _elementsHolder;
    [SerializeField] private Button _button;
    [SerializeField] private Image _topSquare;
    [SerializeField] private Image _bottomSquare;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private Image _startImage;
    [SerializeField] private Image _warmupImage;
    [SerializeField] private Image _testImage;
    [SerializeField] private Image _endImage;

    private float _countdownDuration { get => AppStateMachine.Instance.testSettings.countdownDuration; }

    public event Action ScreenTapped;
    public event Action CountdownFinished;
    public event Action TestEnded;

    private void Awake()
    {
        HideAllElements();
    }

    public void ActivateTopSquare()
    {
        _topSquare.gameObject.SetActive(true);
    }

    public void ActivateBottomSquare()
    {
        _bottomSquare.gameObject.SetActive(true);
    }

    public void HideSquares()
    {
        _topSquare.gameObject.SetActive(false);
        _bottomSquare.gameObject.SetActive(false);
    }

    public void HideAllElements()
    {
        _elementsHolder.SetActive(false);
    }

    public void ShowAllElements()
    {
        _elementsHolder.SetActive(true);
        SetUpButton();
    }

    public void HideAllElementsIndividually()
    {
        _button.gameObject.SetActive(false);
        _topSquare.gameObject.SetActive(false);
        _bottomSquare.gameObject.SetActive(false);
        _countdownText.gameObject.SetActive(false);
        _startImage.gameObject.SetActive(false);
        _warmupImage.gameObject.SetActive(false);
        _testImage.gameObject.SetActive(false);
        _endImage.gameObject.SetActive(false);
    }

    public void BeginWarmupCountdown()
    {
        HideAllElementsIndividually();
        _button.gameObject.SetActive(true);
        StartCoroutine(WarmupCountdownCoroutine());
    }

    public void BeginTestCountdown()
    {
        HideAllElementsIndividually();
        _button.gameObject.SetActive(true);
        StartCoroutine(TestCountdownCoroutine());
    }

    public void EndTest()
    {
        HideAllElementsIndividually();
        StartCoroutine(EndTestCoroutine());
    }

    private IEnumerator WarmupCountdownCoroutine()
    {
        _warmupImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(_countdownDuration);
        _warmupImage.gameObject.SetActive(false);
        StartCoroutine(CountdownCoroutine(true));
    }

    private IEnumerator TestCountdownCoroutine()
    {
        _testImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(_countdownDuration);
        _testImage.gameObject.SetActive(false);
        StartCoroutine(CountdownCoroutine(false));
    }

    private IEnumerator CountdownCoroutine(bool isWarmup)
    {
        _countdownText.gameObject.SetActive(true);
        var timer = _countdownDuration;
        while (timer > 0)
        {
            _countdownText.text = timer.ToString();
            yield return new WaitForSeconds(1);
            timer--;
        }
        _countdownText.gameObject.SetActive(false);
        _startImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _startImage.gameObject.SetActive(false);
        CountdownFinished?.Invoke();
    }

    private IEnumerator EndTestCoroutine()
    {
        _endImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(_countdownDuration);
        TestEnded?.Invoke();
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
