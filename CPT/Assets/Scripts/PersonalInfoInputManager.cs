
using TMPro;
using UnityEngine;

[System.Serializable]
public class PersonalInfoInputManager
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

    public string GetInputCharacteristicsData()
    {
        string csvData = $"{playerNameInput.text}, {playerAgeInput.text}, {playerGenderInput.text}, {playerdailySleepTimeInput.text}, {playerBedTimeInput.text}, {playerWakeUpTimeInput.text}";
        return csvData;
    }
}
