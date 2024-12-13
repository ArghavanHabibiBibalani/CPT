
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
    public TMP_InputField playerDailySleepTimeInput;
    [SerializeField]
    public TMP_InputField playerBedTimeInput;
    [SerializeField]
    public TMP_InputField playerWakeUpTimeInput;

    public string GetInputCharacteristicsData()
    {
        string csvData = $"{playerNameInput.text}, {playerAgeInput.text}, {playerGenderInput.text}, {playerDailySleepTimeInput.text}, {playerBedTimeInput.text}, {playerWakeUpTimeInput.text}";
        return csvData;
    }

    public void Reset()
    {
        playerNameInput.text = string.Empty;
        playerAgeInput.text = string.Empty;
        playerGenderInput.text = string.Empty;
        playerDailySleepTimeInput.text = string.Empty;
        playerBedTimeInput.text = string.Empty;
        playerWakeUpTimeInput.text = string.Empty;
    }
}
