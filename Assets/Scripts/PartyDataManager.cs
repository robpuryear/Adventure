using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PartyDataManager : MonoBehaviour
{
    public PlayerData player1;
    public PlayerData player2;
    public PlayerData player3;
    public PlayerData player4;

    public Image player1Hair;
    public Image player1FacialHair;
    public Image player1Shirt;
    public Image player1Pants;
    public Image player1Shoes;
    public Image player1Eyes;

    public Text player1Name;
    public Text player2Name;
    public Text player3Name;
    public Text player4Name;

    public Image player2Hair;
    public Image player2FacialHair;
    public Image player2Shirt;
    public Image player2Pants;
    public Image player2Shoes;
    public Image player2Eyes;


    public Image player3Hair;
    public Image player3FacialHair;
    public Image player3Shirt;
    public Image player3Pants;
    public Image player3Shoes;
    public Image player3Eyes;


    public Image player4Hair;
    public Image player4FacialHair;
    public Image player4Shirt;
    public Image player4Pants;
    public Image player4Shoes;
    public Image player4Eyes;


    public string playerBtn;

    void Start()
    {
        LoadPlayer1();
        LoadPlayer2();
        LoadPlayer3();
        LoadPlayer4();

    }

    public void LoadPlayer1()
    {
        player1 = new PlayerData();
        string json = ReadFromFile("player1.txt");
        JsonUtility.FromJsonOverwrite(json, player1);

        player1Name.text = player1.name;
        player1Hair.sprite = Resources.Load<Sprite>("Art/" + player1.hair);
        player1FacialHair.sprite = Resources.Load<Sprite>("Art/" + player1.facialHair);
        player1Shoes.sprite = Resources.Load<Sprite>("Art/" + player1.shoes);
        player1Pants.sprite = Resources.Load<Sprite>("Art/" + player1.pants);
        player1Shirt.sprite = Resources.Load<Sprite>("Art/" + player1.shirt);
        player1Eyes.sprite = Resources.Load<Sprite>("Art/" + player1.eyes);

    }

    public void LoadPlayer2()
    {
        player2 = new PlayerData();
        string json = ReadFromFile("player2.txt");
        JsonUtility.FromJsonOverwrite(json, player2);

        player2Name.text = player2.name;
        player2Hair.sprite = Resources.Load<Sprite>("Art/" + player2.hair);
        player2FacialHair.sprite = Resources.Load<Sprite>("Art/" + player2.facialHair);
        player2Shoes.sprite = Resources.Load<Sprite>("Art/" + player2.shoes);
        player2Pants.sprite = Resources.Load<Sprite>("Art/" + player2.pants);
        player2Shirt.sprite = Resources.Load<Sprite>("Art/" + player2.shirt);
        player2Eyes.sprite = Resources.Load<Sprite>("Art/" + player2.eyes);
    }
    public void LoadPlayer3()
    {
        player3 = new PlayerData();
        string json = ReadFromFile("player3.txt");
        JsonUtility.FromJsonOverwrite(json, player3);

        player3Name.text = player3.name;
        player3Hair.sprite = Resources.Load<Sprite>("Art/" + player3.hair);
        player3FacialHair.sprite = Resources.Load<Sprite>("Art/" + player3.facialHair);
        player3Shoes.sprite = Resources.Load<Sprite>("Art/" + player3.shoes);
        player3Pants.sprite = Resources.Load<Sprite>("Art/" + player3.pants);
        player3Shirt.sprite = Resources.Load<Sprite>("Art/" + player3.shirt);
        player3Eyes.sprite = Resources.Load<Sprite>("Art/" + player3.eyes);
    }
    public void LoadPlayer4()
    {
        player4 = new PlayerData();
        string json = ReadFromFile("player4.txt");
        JsonUtility.FromJsonOverwrite(json, player4);

        player4Name.text = player4.name;
        player4Hair.sprite = Resources.Load<Sprite>("Art/" + player4.hair);
        player4FacialHair.sprite = Resources.Load<Sprite>("Art/" + player4.facialHair);
        player4Shoes.sprite = Resources.Load<Sprite>("Art/" + player4.shoes);
        player4Pants.sprite = Resources.Load<Sprite>("Art/" + player4.pants);
        player4Shirt.sprite = Resources.Load<Sprite>("Art/" + player4.shirt);
        player4Eyes.sprite = Resources.Load<Sprite>("Art/" + player4.eyes);
    }

    public void WhichPlayer()
    {
        playerBtn = EventSystem.current.currentSelectedGameObject.name;

        PlayerPrefs.SetString("player", playerBtn);
    }

    //public void Load(string file)
    //{
    //    data = new PlayerData();
    //    string json = ReadFromFile(file);
    //    JsonUtility.FromJsonOverwrite(json, data);
    //}

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
