using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "countdown Settings")]
public class CountdownSettings : ScriptableObject
{
    [SerializeField] private float _duration;

    public float Duration { get => _duration; }
}
