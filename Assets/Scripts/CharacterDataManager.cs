﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;

public class CharacterDataManager : MonoBehaviour
{
    //private string file = "player1.txt";

    public PlayerData data;

    //public void Save()
    //{
    //    string json = JsonUtility.ToJson(data);
    //    WriteToFile(file, json);
    //}

    public void Save(string fileName)
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(fileName, json);
    }

    public void Load(string fileName)
    {
        data = new PlayerData();
        string json = ReadFromFile(fileName);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            var textFile = Resources.Load<TextAsset>("emptyPlayer");
            return textFile.ToString();
        }

    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

}
