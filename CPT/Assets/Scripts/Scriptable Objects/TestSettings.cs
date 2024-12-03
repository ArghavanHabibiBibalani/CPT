using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test Settings")]
public class TestSettings : ScriptableObject
{
    [SerializeField] private float _countdownDuration;

    [SerializeField] private int _warmupTrialCount;
    [SerializeField] private int _warmupPartCount;

    [SerializeField] private int _testTrialCount;
    [SerializeField] private int _testPartCount;

    [SerializeField, Range(0f, 1f)] private float _topSquarePercentage;

    [SerializeField] private float _squareVisibilityDuration;
    [SerializeField] private float _gapDuration;
    [SerializeField] private float _breakDuration;
    [SerializeField] private float _minimumReactionTime;

    public float countdownDuration { get => _countdownDuration; }

    public int warmupTrialCount { get => _warmupTrialCount; }
    public int warmupPartCount {  get => _warmupPartCount; }

    public int testTrialCount { get => _testTrialCount; }
    public int testPartCount { get => _testPartCount; }

    public float topSquarePercentage { get => _topSquarePercentage; }

    public float squareVisibilityDuration {  get => _squareVisibilityDuration; }
    public float gapDuration {  get => _gapDuration; }
    public float breakDuration { get => _breakDuration; }
    public float minimumReactionTime { get => _minimumReactionTime; }
}
