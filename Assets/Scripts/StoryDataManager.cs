using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;

public class StoryDataManager : MonoBehaviour
{
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

}
