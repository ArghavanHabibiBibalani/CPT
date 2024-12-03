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

    /// <summary>
    /// true = square on top
    /// </summary>
    private List<bool> _squaresSequence;

    public TestManager(TestSettings testSettings, TestUIView testUIView, bool isWarmup)
    {
        _testSettings = testSettings;
        _testUIView = testUIView;
        
        InitializeListeners();

        _totalTrials = isWarmup ? _testSettings.warmupTrialCount : _testSettings.testTrialCount;
        _totalParts = isWarmup ? _testSettings.warmupPartCount : _testSettings.testPartCount;
        _trialsPerPart = _totalTrials / _totalParts;
        InitializeTopSquareTrialCount(isWarmup);

        InitializeSquareSequence();

        BeginTest();
    }

    public void BeginTest()
    {
        _testUIView.HideAllElements();
        _testUIView.BeginCountdown(_testSettings.countdownDuration);
    }

    public void OnScreenTapped()
    {

    }

    private void OnCountdownFinished()
    {
        _testUIView.StartCoroutine(BeginTrials());
    }

    private IEnumerator BeginTrials()
    {
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
        // Save and proceed to the results?
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

    private void InitializeListeners()
    {
        _testUIView.ScreenTapped += OnScreenTapped;
        _testUIView.CountdownFinished += OnCountdownFinished;
    }

    private void InitializeTopSquareTrialCount(bool isWarmup)
    {
        var trialCount = isWarmup ? _testSettings.warmupTrialCount : _testSettings.testTrialCount;
        _topSquareTrials = (int)(trialCount * _testSettings.topSquarePercentage);
    }

    private void PrintList<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.Log("List is empty or null.");
            return;
        }

        string output = string.Join(", ", list);
        Debug.Log($"List contents: [{output}]");
    }
}
