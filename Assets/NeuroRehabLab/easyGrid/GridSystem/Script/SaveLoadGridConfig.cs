using System;
using System.IO;
using UnityEngine;

public class SaveLoadGridConfig : MonoBehaviour
{
        public static SaveLoadGridConfig Instance;
        private string _pathToData;
        private string _jsonString;
        public RootObject _loadGridData;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _loadGridData = new RootObject();
        LoadDataFromFile();
    }

    //Function that we call to save our grid parameters to a JSON file
    public void SaveSettings(GridConfig thisSession)
    {
            CheckDataFolder();
            var json = JsonUtility.ToJson(thisSession);

            _jsonString += Environment.NewLine + json + "]";
            Debug.Log(_jsonString);

            File.WriteAllText(_pathToData, _jsonString);
    }

    private void CheckDataFolder()
    {
        _pathToData = Application.dataPath + "/NeuroRehabLab/easyGrid/GridSystem/Script/model/GridSaveFile.json";

        ReadString();
    }

    private void ReadString()
    {
        try
        {
            var reader = new StreamReader(_pathToData);
            var value = reader.ReadToEnd();
            value = value.Substring(0, value.Length - 1);
            _jsonString = value + ",";
            Debug.Log(value);

            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }   
    }

    //Function that will load parameters from a JSON file
    public void LoadDataFromFile()
    {
        try
        {
            var readJson = File.ReadAllText(Application.dataPath + "/NeuroRehabLab/easyGrid/GridSystem/Script/model/GridSaveFile.json");
            //_loadGridData = JsonUtility.FromJson<RootObject>(readJson);
            _loadGridData = JsonUtility.FromJson<RootObject>("{\"Grid\":" + readJson + "}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}