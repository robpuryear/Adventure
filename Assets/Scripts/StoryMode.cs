using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryMode : MonoBehaviour
{
    // SerializeField makes the variable available in the inspector
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] Image storyImage;
    [SerializeField] Text choice1BtnText;
    [SerializeField] Text choice2BtnText;
    [SerializeField] Text continueBtnText;

    GameObject choice1Btn;
    GameObject choice2Btn;
    GameObject continueBtn;

    State state;
    State[] nextStates;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        storyImage.sprite = state.GetStoryImage();

        choice1BtnText.text = state.GetButton1Text();
        choice2BtnText.text = state.GetButton2Text();

        // hide choice1 button
        choice1Btn = GameObject.Find("Choice1 Btn");
        choice2Btn = GameObject.Find("Choice2 Btn");
        continueBtn = GameObject.Find("Continue Btn");

    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        // get the array of possible states for the current state
        nextStates = state.GetNextStates();

        // update the screen with the state data
        textComponent.text = state.GetStateStory();
        storyImage.sprite = state.GetStoryImage();
        choice1BtnText.text = state.GetButton1Text();
        choice2BtnText.text = state.GetButton2Text();
        continueBtnText.text = state.GetContinueBtnText();

        // if there is no text for a button in a state, hide the button
        if(choice1BtnText.text == "")
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

        if (continueBtnText.text == "")
        {
            hideContinueBtn();
        }
        else
        {
            showContinueBtn();
        }

    }

    public void Btn1Pressed()
    {
        state = nextStates[0];
    }

    public void Btn2Pressed()
    {
        state = nextStates[1];
    }

    public void ContinueBtnPressed()
    {
        state = nextStates[0];
    }

    public void hideBtn1()
    {
        choice1Btn.SetActive(false);
    }

    public void hideBtn2()
    {
        choice2Btn.SetActive(false);
    }

    public void hideContinueBtn()
    {
        continueBtn.SetActive(false);
    }

    public void showBtn1()
    {
        choice1Btn.SetActive(true);
    }

    public void showBtn2()
    {
        choice2Btn.SetActive(true);
    }

    public void showContinueBtn()
    {
        continueBtn.SetActive(true);
    }


}
