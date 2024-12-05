using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FSaveCharecteristicsData : MonoBehaviour
{
    [SerializeField]
    private SInputCharecteristics playerData;

    [SerializeField]
    private Button _saveButton;

    private bool isDataSaved = false;

    string filePath = Path.Combine(Application.streamingAssetsPath, "playerData.csv");
    public FSaveCharecteristicsData()
    {
        playerData = new SInputCharecteristics();
    }
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
    private void Start()
    {
        if (_saveButton != null)
        {
            _saveButton.onClick.AddListener(SavePlayerData);
        }
        else
        {
            Debug.LogError("Save Button is not assigned in the Inspector!");
        }
    }

    public void SavePlayerData()
    {
        if (isDataSaved)
        {
            Debug.LogWarning("Data already saved. Modify input fields to save new data.");
            return;
        }
        string csvRow = playerData.GetInputCharecteristicsData();

        string path = Path.Combine(Application.streamingAssetsPath, filePath);

        File.AppendAllText(path, csvRow + "\n");

        Debug.Log("Player data saved: " + csvRow);

        isDataSaved = true;
    }


}

