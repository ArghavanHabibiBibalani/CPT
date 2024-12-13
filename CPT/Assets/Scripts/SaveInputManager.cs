using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SaveInputManager : MonoBehaviour
{
    private bool isInputDataSaved = false;
    private bool isRecordedDataSaved = false;
    private string currentRowData = "";

    string filePath = Path.Combine(Application.streamingAssetsPath, "playerData.csv");

    private void Awake()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Name,Age,Gender,Daily Sleep Time,Bed Time,Wake Up Time,total in the zone,total out of the zone,total too early,total too late,total mistakes,highest in the zone streak\n");
        }
        else
        {
            if (new FileInfo(filePath).Length == 0)
            {
                File.WriteAllText(filePath, "Name,Age,Gender,Daily Sleep Time,Bed Time,Wake Up Time,total in the zone,total out of the zone,total too early,total too late,total mistakes,highest in the zone streak\n");

            }
        }
    }

    public void SavePlayerData(string dataToSave)
    {
        if (isInputDataSaved)
        {
            Debug.LogWarning("Data already saved. Modify input fields to save new data.");
            return;
        }

        currentRowData = dataToSave;
        isInputDataSaved = true;

        SaveCurrentRow();
    }

    public void SaveRecordedData(string recordedData)
    {
        if (isRecordedDataSaved)
        {
            Debug.LogWarning("Recorded data already saved for this row. Modify input fields to save new data.");
            return;
        }

        if (string.IsNullOrWhiteSpace(recordedData))
        {
            Debug.LogError("Recorded data is empty or null.");
            return;
        }

        currentRowData += "," + recordedData;
        isRecordedDataSaved = true;

        SaveCurrentRow();
    }

    private void SaveCurrentRow()
    {
        if (isInputDataSaved && isRecordedDataSaved)
        {
            File.AppendAllText(filePath, currentRowData + "\n");
            Debug.Log("Data saved successfully to: " + filePath);
        }
    }

    public void ResetRowBuffer()
    {
        currentRowData = "";
        isInputDataSaved = false;
        isRecordedDataSaved = false;
    }
}

