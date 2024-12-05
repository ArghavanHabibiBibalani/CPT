using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class FSaveCharecteristicsData
{
    private string Name;
    private string Age;
    private string Gender;
    private string DailySleepTime;
    private string BedTime;
    private string WakeUpTime;

    private SInputCharecteristics playerData;

    public static string FilePath => Path.Combine(Application.persistentDataPath, "UserData.xlsx");

    public FSaveCharecteristicsData()
    {
        playerData = new SInputCharecteristics();
    }


    public void SavePlayerData()
    {
       // string json = JsonUtility.ToJson
    }

    private void ConvetInputData(SInputCharecteristics input)
    {
        Name = input.playerNameInput.text;
        Age = input.playerAgeInput.text;
        Gender = input.playerGenderInput.text;
        DailySleepTime = input.playerdailySleepTimeInput.text;
        BedTime = input.playerBedTimeInput.text;
        WakeUpTime = input.playerWakeUpTimeInput.text;
    }

}

