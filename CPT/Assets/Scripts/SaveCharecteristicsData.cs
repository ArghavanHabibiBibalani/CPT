using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SaveCharecteristicsData : MonoBehaviour
{
    //[SerializeField]
    //private SInputCharecteristics playerData;

    //[SerializeField]
    //private Button _saveButton;

    private bool isDataSaved = false;

    string filePath = Path.Combine(Application.streamingAssetsPath, "playerData.csv");
   
    private void Awake()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Name,Age,Gender,Daily Sleep Time,Bed Time,Wake Up Time\n");
        }
        else
        {
            if (new FileInfo(filePath).Length == 0)
            {
                File.WriteAllText(filePath, "Name,Age,Gender,Daily Sleep Time,Bed Time,Wake Up Time\n");
            }
        }
    }
   
    public void SavePlayerData(string dataToSave)
    {
        if (isDataSaved)
        {
            Debug.LogWarning("Data already saved. Modify input fields to save new data.");
            return;
        }
        try
        {
            File.AppendAllText(filePath, dataToSave + "\n");
            Debug.Log("Data saved successfully to: " + filePath);
            isDataSaved = true;
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save player data: " + e.Message);
        }
         
    }
}

