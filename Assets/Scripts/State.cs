using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this is a template where we can create new State objects

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{
    [TextArea(14, 10)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] Sprite image;

    [SerializeField] string choice1BtnText;
    [SerializeField] string choice2BtnText;
    [SerializeField] string continueBtnText;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public Sprite GetStoryImage()
    {
        return image;
    }

    public string GetButton1Text()
    {
        return choice1BtnText;
    }

    public string GetButton2Text()
    {
        return choice2BtnText;
    }

    public string GetContinueBtnText()
    {
        return continueBtnText;
    }
}
