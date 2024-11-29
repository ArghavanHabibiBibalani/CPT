using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager
{
    private WarmupUIView _warmupUIView;
    private CountdownSettings _countdownSettings;

    public TestManager(CountdownSettings countdownSettings)
    {
        _countdownSettings = countdownSettings;
        _warmupUIView = Object.FindObjectOfType<WarmupUIView>();
        _warmupUIView.ScreenTapped += OnScreenTapped;
    }
    public void BeginTest()
    {
        _warmupUIView.HideAllElements();
        _warmupUIView.BeginCountdown(_countdownSettings.Duration);
    }

    public void OnScreenTapped()
    {

    }

    private void BeginTrials()
    {

    }
}
