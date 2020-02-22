using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class StoryMode : MonoBehaviour
{
    public Text textComponent;
    public Image storyImage;
    public Text choice1BtnText;
    public Text choice2BtnText;
    public Text choice3BtnText;

    public StoryDataManager dataManager;

    GameObject choice1Btn;
    GameObject choice2Btn;
    GameObject choice3Btn;

    void Start()
    {
        dataManager.LoadStartupJSON();

        // get a reference to the buttons
        choice1Btn = GameObject.Find("Choice1 Btn");
        choice2Btn = GameObject.Find("Choice2 Btn");
        choice3Btn = GameObject.Find("Choice3 Btn");

    }

    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        textComponent.text = dataManager.json["storyText"].Value;
        choice1BtnText.text = dataManager.json["btn1Text"].Value;
        choice2BtnText.text = dataManager.json["btn2Text"].Value;
        choice3BtnText.text = dataManager.json["btn3Text"].Value;
        storyImage.sprite = dataManager.LoadStorySprite();

        // if there is no text for a button in a state, hide the button
        if (choice1BtnText.text == "")
        {
            hideBtn1();
        }
        else
        {
            showBtn1();
        }

        if (choice2BtnText.text == "")
        {
            hideBtn2();
        }
        else
        {
            showBtn2();
        }

        if (choice3BtnText.text == "")
        {
            hideBtn3();
        }
        else
        {
            showBtn3();
        }

    }

    public void Btn1Pressed()
    {
        dataManager.LoadNextState(dataManager.json["states"][0]["btn1"]);
    }

    public void Btn2Pressed()
    {
        dataManager.LoadNextState(dataManager.json["states"][0]["btn2"]);
    }

    public void Btn3BtnPressed()
    {
        dataManager.LoadNextState(dataManager.json["states"][0]["btn3"]);
    }

    public void hideBtn1()
    {
        choice1Btn.SetActive(false);
    }

    public void hideBtn2()
    {
        choice2Btn.SetActive(false);
    }

    public void hideBtn3()
    {
        choice3Btn.SetActive(false);
    }

    public void showBtn1()
    {
        choice1Btn.SetActive(true);
    }

    public void showBtn2()
    {
        choice2Btn.SetActive(true);
    }

    public void showBtn3()
    {
        choice3Btn.SetActive(true);
    }


}
