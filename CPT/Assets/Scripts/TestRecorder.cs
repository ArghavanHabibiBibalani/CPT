
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
    }

    public void StopTimer()
    {
        if (_tappedThisTrial == false)
        {
            DidNotTap();
        }

        _testIsRunning = false;
        _tappedThisTrial = false;
        _timer = 0;
    }

    public string RecordedData()
    {
        return $"{_totalInTheZone}, " +
            $"{_totalTooEarly + _totalTooLate}, " +
            $"{_totalTooEarly}, " +
            $"{_totalTooLate}, " +
            $"{_highestInTheZoneStreak}, " +
            $"{string.Join(", ", _timeRecords)}";
    }

    private void OnScreenTapped()
    {
        _tappedThisTrial = true;
        if (_isTopSquare == false)
        {
            MadeMistake();
            _timeRecords.Add($"Mistake: {_timer:f2}");
        }
        else
        {
            if (_timer < settings.minimumReactionTime)
            {
                TappedTooEarly();
            }
            else
            {
                TappedInTheZone();
            }
        }
        _timeRecords.Add($"{_timer:f2}");
    }

    private void TappedTooEarly()
    {
        _totalTooEarly++;
        UpdateHighestStreak();
    }
    
    private void TappedInTheZone()
    {
        _totalInTheZone++;
        _currentInTheZoneStreak++;
    }

    private void DidNotTap()
    {
        _timeRecords.Add("Too late");
        _totalTooLate++;
        UpdateHighestStreak();
    }

    private void MadeMistake()
    {
        _totalMistakes++;
        UpdateHighestStreak();
    }

    private void UpdateHighestStreak()
    {
        if (_currentInTheZoneStreak > _highestInTheZoneStreak)
        {
            _highestInTheZoneStreak = _currentInTheZoneStreak;
        }
    }
}
