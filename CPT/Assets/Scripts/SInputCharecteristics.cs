using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SInputCharecteristics : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField playerNameInput;
    [SerializeField]
    public TMP_InputField playerAgeInput;
    [SerializeField]
    public TMP_InputField playerGenderInput;
    [SerializeField]
    public TMP_InputField playerdailySleepTimeInput;
    [SerializeField]
    public TMP_InputField playerBedTimeInput;
    [SerializeField]
    public TMP_InputField playerWakeUpTimeInput;

    public string GetInputCharecteristicsData()
    {
        string csvData = $"{playerNameInput.text}, {playerAgeInput.text}, {playerGenderInput.text}, {playerdailySleepTimeInput.text}, {playerBedTimeInput.text}, {playerWakeUpTimeInput.text}";
        return csvData;
    }
}
