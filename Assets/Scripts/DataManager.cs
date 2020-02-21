using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;

public class DataManager : MonoBehaviour
{
    public JSONState state;
    public JSONNode json;

    public Sprite LoadStorySprite()
    {
        var sprite = Resources.Load<Sprite>(json["storyImage"].Value);
        return sprite;
    }

    public void LoadStartupJSON()
    {
        //Load text from a JSON file (Assets/Resources/startingState.json)
        var jsonTextFile = Resources.Load<TextAsset>("States/startingState");
        json = JSON.Parse(jsonTextFile.ToString());
    }

    public void LoadNextState(string file)
    {
        var jsonTextFile = Resources.Load<TextAsset>("States/" + file);
        json = JSON.Parse(jsonTextFile.ToString());
    }

    //public void Save()
    //{
    //    string json = JsonUtility.ToJson(state);
    //    WriteToFile(file, json);
    //}

    //public void Load()
    //{
    //    state = new JSONState();
    //    string json = ReadFromFile(file);
    //    JsonUtility.FromJsonOverwrite(json, state);
    //}

    //private void WriteToFile(string fileName, string json)
    //{
    //    string path = GetFilePath(fileName);
    //    FileStream fileStream = new FileStream(path, FileMode.Create);

    //    using (StreamWriter writer = new StreamWriter(fileStream))
    //    {
    //        writer.Write(json);
    //    }
    //}

    //private string ReadFromFile(string fileName)
    //{
    //    string path = GetFilePath(fileName);
    //    if (File.Exists(path))
    //    {
    //        using (StreamReader reader = new StreamReader(path))
    //        {
    //            string json = reader.ReadToEnd();
    //            return json;
    //        }
    //    }
    //    else
    //        Debug.LogWarning("File not found!");

    //    return "";
    //}

    //private string GetFilePath(string fileName)
    //{
    //    return Application.persistentDataPath + "/" + fileName;
    //}

}
