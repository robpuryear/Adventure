using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public InputField playerName;
    public Text strong;

    public DataManager dataManager;

    public void IncreaseStrong()
    {
        dataManager.data.strong += 1;
        strong.text = dataManager.data.strong.ToString();
    }

    public void DecreaseStrong()
    {
        dataManager.data.strong -= 1;
        strong.text = dataManager.data.strong.ToString();
    }

    public void ChangeName(string text)
    {
        dataManager.data.name = text;
    }

    public void ClickSave()
    {
        dataManager.Save();
    }

    // Start is called before the first frame update
    void Start()
    {
        dataManager.Load();
        playerName.text = dataManager.data.name;
        strong.text = dataManager.data.strong.ToString();
    }

}
