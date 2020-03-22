using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMissionScene()
    {
        SceneManager.LoadScene("MissionHome");
    }

    public void LoadEditCharacterScene()
    {
        SceneManager.LoadScene("PlayerCreator");
    }

    public void LoadPartyScene()
    {
        SceneManager.LoadScene("PartyScene");
    }

    public void LoadStoryScene()
    {
        SceneManager.LoadScene("StoryScene");
    }
}
