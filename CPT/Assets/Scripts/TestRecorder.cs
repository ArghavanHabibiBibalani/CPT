
using StatePattern;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestRecorder : MonoBehaviour
{
    [SerializeField] private TestUIView _testUIView;

    private List<string> _timeRecords = new List<string>();

    private float _timer;

    private int _totalInTheZone;
    private int _totalTooEarly;
    private int _totalTooLate;
    private int _totalMistakes;

    private int _currentInTheZoneStreak;
    private int _highestInTheZoneStreak;

    private bool _testIsRunning;
    private bool _tappedThisTrial;

    private bool _isTopSquare;

    private TestSettings settings => AppStateMachine.Instance.testSettings;

    private void Awake()
    {
        _testUIView.ScreenTapped += OnScreenTapped;
    }

    private void Update()
    {
        if (_testIsRunning)
        {
            _timer += Time.deltaTime;
        }
    }

    public void StartTimer(bool isTopSquare)
    {
        _testIsRunning = true;
        _isTopSquare = isTopSquare;
    }

    public void StopTimer()
    {
        if (_testIsRunning == false)
        {
            return;
        }

        if (_tappedThisTrial == false)
        {
            DidNotTap();
        }

        _testIsRunning = false;
        _tappedThisTrial = false;
        _timer = 0;
        UpdateHighestStreak();
    }


    public void ResetCurrentStreak()
    {
        _currentInTheZoneStreak = 0;
    }

    public string RecordedData()
    {
        return $"{_totalInTheZone}, " +
            $"{_totalTooEarly + _totalTooLate + _totalMistakes}, " +
            $"{_totalTooEarly}, " +
            $"{_totalTooLate}, " +
            $"{_totalMistakes}, " +
            $"{_highestInTheZoneStreak}, " +
            $"{string.Join(", ", _timeRecords)}";
    }

    private void OnScreenTapped()
    {
        if (_testIsRunning == false || _tappedThisTrial)
        {
            return;        
        }

        _tappedThisTrial = true;

        if (_isTopSquare == false)
        {
            MadeMistake();
        }

        else
        {
            if (_timer < settings.minimumReactionTime)
            {
                TappedTooEarly();
            }
            else
            {
                WasInTheZone();
            }
        }
    }

    private void TappedTooEarly()
    {
        _totalTooEarly++;
        UpdateHighestStreak();
        _timeRecords.Add($"{_timer:f2}");
        ResetCurrentStreak();
        //print($"Too early: {_timer:f2}");
    }

    private void WasInTheZone()
    {
        _totalInTheZone++;
        _currentInTheZoneStreak++;
        _timeRecords.Add($"{_timer:f2}");
        //print($"In Zone: {_timer:f2}");
    }

    private void DidNotTap()
    {
        if (_isTopSquare == false)
        {
            WasInTheZone();
            return;
        }

        _timeRecords.Add("Too late");
        _totalTooLate++;
        UpdateHighestStreak();
        ResetCurrentStreak();
        //print($"Didn't tap: {_timer:f2}");
    }

    private void MadeMistake()
    {
        _timeRecords.Add($"Mistake: {_timer:f2}");
        _totalMistakes++;
        UpdateHighestStreak();
        ResetCurrentStreak();
        //print($"Mistake: {_timer:f2}");
    }

    private void UpdateHighestStreak()
    {
        if (_currentInTheZoneStreak > _highestInTheZoneStreak)
        {
            _highestInTheZoneStreak = _currentInTheZoneStreak;
        }
    }
}
