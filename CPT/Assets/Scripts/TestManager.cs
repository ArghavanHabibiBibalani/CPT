using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestManager
{
    private TestUIView _testUIView;
    private TestSettings _testSettings;

    private int _totalTrials;
    private int _totalParts;
    private int _trialsPerPart;
    private int _topSquareTrials;

    private bool _isWarmup;

    /// <summary>
    /// true = square on top
    /// </summary>
    private List<bool> _squaresSequence;

    public event Action WarmupFinished;
    public event Action TestFinished;

    public TestManager(TestSettings testSettings, TestUIView testUIView)
    {
        _testSettings = testSettings;
        _testUIView = testUIView;
        _testUIView.CountdownFinished += OnCountdownFinished;
    }

    public void BeginWarmup()
    {
        _isWarmup = true;
        _testUIView.BeginWarmupCountdown();
    }

    public void BeginTest()
    {
        _isWarmup = false;
        _testUIView.BeginTestCountdown();
    }

    private void OnCountdownFinished()
    {
        if (_isWarmup)
        {
            _testUIView.StartCoroutine(BeginTrials(true));
        }
        else
        {
            _testUIView.StartCoroutine(BeginTrials(false));
        }
    }

    private IEnumerator BeginTrials(bool isWarmup)
    {
        SetInitialData(isWarmup);
        var trialCounter = 0;
        var partCounter = 0;
        while (partCounter < _totalParts)
        {
            while (trialCounter < _trialsPerPart)
            {
                yield return new WaitForSeconds(_testSettings.gapDuration);
                var squareIndex = (partCounter * _trialsPerPart) + trialCounter;
                ActivateSquare(squareIndex);
                yield return new WaitForSeconds(_testSettings.squareVisibilityDuration);
                _testUIView.HideSquares();
                trialCounter++;
            }
            trialCounter = 0;
            partCounter++;
            yield return new WaitForSeconds(_testSettings.breakDuration);
        }
        if (isWarmup)
        {
            WarmupFinished?.Invoke();
        }
        else
        {
            TestFinished?.Invoke();
        }
        _testUIView.EndTest();
        // Save and proceed to the results?
    }
    private void SetInitialData(bool isWarmup)
    {
        _totalTrials = isWarmup ? _testSettings.warmupTrialCount : _testSettings.testTrialCount;
        _totalParts = isWarmup ? _testSettings.warmupPartCount : _testSettings.testPartCount;
        _trialsPerPart = _totalTrials / _totalParts;
        _topSquareTrials = (int)(_totalTrials * _testSettings.topSquarePercentage);
        InitializeSquareSequence();
    }

    private void ActivateSquare(int index)
    {
        if (_squaresSequence[index] == true)
        {
            Debug.Log("Top square");
            _testUIView.ActivateTopSquare();
        }
        else
        {
            Debug.Log("Bottom square");
            _testUIView.ActivateBottomSquare();
        }
    }

    private void InitializeSquareSequence()
    {
        _squaresSequence = new List<bool>();

        for (int i = 0; i < _topSquareTrials; i++)
            _squaresSequence.Add(true);

        for (int i = _topSquareTrials; i < _totalTrials; i++)
            _squaresSequence.Add(false);

        Utility.ShuffleList(_squaresSequence);
    }
}
