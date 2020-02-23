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


    public Image player2Hair;
    public Image player2FacialHair;
    public Image player2Shirt;
    public Image player2Pants;
    public Image player2Shoes;


    public Image player3Hair;
    public Image player3FacialHair;
    public Image player3Shirt;
    public Image player3Pants;
    public Image player3Shoes;


    public Image player4Hair;
    public Image player4FacialHair;
    public Image player4Shirt;
    public Image player4Pants;
    public Image player4Shoes;

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

        if (player1.hair.Length > 0)
        {
            player1Hair.sprite = Resources.Load<Sprite>("Art/" + player1.hair);
            player1Hair.color = player1.hairColor;
        }
        if (player1.facialHair.Length > 0)
        {
            player1FacialHair.sprite = Resources.Load<Sprite>("Art/" + player1.facialHair);
        }
        if (player1.shoes.Length > 0)
        {
            player1Shoes.sprite = Resources.Load<Sprite>("Art/" + player1.shoes);
        }
        if (player1.pants.Length > 0)
        {
            player1Pants.sprite = Resources.Load<Sprite>("Art/" + player1.pants);
        }
        if (player1.shirt.Length > 0)
        {
            player1Shirt.sprite = Resources.Load<Sprite>("Art/" + player1.shirt);
        }
    }

    public void LoadPlayer2()
    {
        player2 = new PlayerData();
        string json = ReadFromFile("player2.txt");
        JsonUtility.FromJsonOverwrite(json, player2);

        if (player2.hair.Length > 0)
        {
            player2Hair.sprite = Resources.Load<Sprite>("Art/" + player2.hair);
            player2Hair.color = player2.hairColor;
        }
        if (player2.facialHair.Length > 0)
        {
            player2FacialHair.sprite = Resources.Load<Sprite>("Art/" + player2.facialHair);
        }
        if (player2.shoes.Length > 0)
        {
            player2Shoes.sprite = Resources.Load<Sprite>("Art/" + player2.shoes);
        }
        if (player2.pants.Length > 0)
        {
            player2Pants.sprite = Resources.Load<Sprite>("Art/" + player2.pants);
        }
        if (player2.shirt.Length > 0)
        {
            player2Shirt.sprite = Resources.Load<Sprite>("Art/" + player2.shirt);
        }
    }
    public void LoadPlayer3()
    {
        player3 = new PlayerData();
        string json = ReadFromFile("player3.txt");
        JsonUtility.FromJsonOverwrite(json, player3);

        if (player3.hair.Length > 0)
        {
            player3Hair.sprite = Resources.Load<Sprite>("Art/" + player3.hair);
            player3Hair.color = player3.hairColor;
        }
        if (player3.facialHair.Length > 0)
        {
            player3FacialHair.sprite = Resources.Load<Sprite>("Art/" + player3.facialHair);
        }
        if (player3.shoes.Length > 0)
        {
            player3Shoes.sprite = Resources.Load<Sprite>("Art/" + player3.shoes);
        }
        if (player3.pants.Length > 0)
        {
            player3Pants.sprite = Resources.Load<Sprite>("Art/" + player3.pants);
        }
        if (player3.shirt.Length > 0)
        {
            player3Shirt.sprite = Resources.Load<Sprite>("Art/" + player3.shirt);
        }
    }
    public void LoadPlayer4()
    {
        player4 = new PlayerData();
        string json = ReadFromFile("player4.txt");
        JsonUtility.FromJsonOverwrite(json, player4);

        if (player4.hair.Length > 0)
        {
            player4Hair.sprite = Resources.Load<Sprite>("Art/" + player4.hair);
            player4Hair.color = player4.hairColor;
        }
        if (player4.facialHair.Length > 0)
        {
            player4FacialHair.sprite = Resources.Load<Sprite>("Art/" + player4.facialHair);
        }
        if (player4.shoes.Length > 0)
        {
            player4Shoes.sprite = Resources.Load<Sprite>("Art/" + player4.shoes);
        }
        if (player4.pants.Length > 0)
        {
            player4Pants.sprite = Resources.Load<Sprite>("Art/" + player4.pants);
        }
        if (player4.shirt.Length > 0)
        {
            player4Shirt.sprite = Resources.Load<Sprite>("Art/" + player4.shirt);
        }
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
