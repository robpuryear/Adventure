﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour
{

    public InputField playerName;
    //public Text strong;
    //public Text quick;
    //public Text smart;
    //public Text devoted;
    //public Text tough;
    //public Text charm;

    public CharacterDataManager dataManager;

    public Image hair;
    public Image facialHair;
    public Image shirt;
    public Image pants;
    public Image shoes;
    public Image eyes;

    int hairCounter = -1;
    int facialHairCounter = -1;
    int shirtCounter = -1;
    int pantsCounter = -1;
    int shoesCounter = -1;
    int eyesCounter = -1;

    public Sprite[] nextHair;
    public Sprite[] nextFacialHair;
    public Sprite[] nextShirt;
    public Sprite[] nextPants;
    public Sprite[] nextShoes;
    public Sprite[] nextEyes;

    public string playerBtn;
    public string jsonFile;

    void Start()
    {
        // gets the name of the button that was pressed
        // on the party UI scene which determines
        // which player to edit
        playerBtn = ThisBtnPressed();

        GetCharacter();

        //jsonFile = "player1.txt";
        //dataManager.Load(jsonFile);

        //LoadSavedCharacter();
    }

    public void GetCharacter()
    {
        if (playerBtn.Equals("Character1 Edit Btn"))
        {
            jsonFile = "player1.txt";
            dataManager.Load(jsonFile);

            LoadSavedCharacter();
        }
        else if (playerBtn.Equals("Character2 Edit Btn"))
        {
            jsonFile = "player2.txt";
            dataManager.Load(jsonFile);

            LoadSavedCharacter();
        }
        else if (playerBtn.Equals("Character3 Edit Btn"))
        {
            jsonFile = "player3.txt";
            dataManager.Load(jsonFile);

            LoadSavedCharacter();
        }
        else if (playerBtn.Equals("Character4 Edit Btn"))
        {
            jsonFile = "player4.txt";
            dataManager.Load(jsonFile);

            LoadSavedCharacter();
        }
    }

    public void LoadSavedCharacter()
    {
        playerName.text = dataManager.data.name;
        hair.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.hair);
        facialHair.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.facialHair);
        shoes.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.shoes);
        pants.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.pants);
        shirt.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.shirt);
        eyes.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.eyes);

        //quick.text = dataManager.data.quick.ToString();
        //tough.text = dataManager.data.tough.ToString();
        //devoted.text = dataManager.data.devoted.ToString();
        //smart.text = dataManager.data.smart.ToString();
        //charm.text = dataManager.data.charm.ToString();
        //strong.text = dataManager.data.strong.ToString();

        //if (dataManager.data.hair.Length > 0)
        //{
        //    hair.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.hair);
        //}
        //if (dataManager.data.facialHair.Length > 0)
        //{
        //    facialHair.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.facialHair);
        //}
        //if (dataManager.data.shoes.Length > 0)
        //{
        //    shoes.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.shoes);
        //}
        //if (dataManager.data.pants.Length > 0)
        //{
        //    pants.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.pants);
        //}
        //if (dataManager.data.shirt.Length > 0)
        //{
        //    shirt.sprite = Resources.Load<Sprite>("Art/" + dataManager.data.shirt);
        //}
    }

    public void ScrollUpHair()
    {
        var nextHairs = getNextHair();

        if(hairCounter < nextHairs.Length - 1)
        {
            hairCounter += 1;
            hair.sprite = nextHairs[hairCounter];
        }
        else
        {
            hairCounter = 0;
            hair.sprite = nextHairs[hairCounter];
        }
    }

    public void ScrollDownHair()
    {
        var nextHairs = getNextHair();

        if (hairCounter > 0)
        {
            hairCounter -= 1;
            hair.sprite = nextHairs[hairCounter];
        }
        else
        {
            hairCounter = nextHairs.Length - 1;
            hair.sprite = nextHairs[hairCounter];
        }
    }

    public Sprite[] getNextHair()
    {
        return nextHair;
    }

    public void ScrollUpBeard()
    {
        var nextFacialHairs = getNextFacialHair();

        if (facialHairCounter < nextFacialHairs.Length - 1)
        {
            facialHairCounter += 1;
            facialHair.sprite = nextFacialHairs[facialHairCounter];
        }
        else
        {
            facialHairCounter = 0;
            facialHair.sprite = nextFacialHairs[facialHairCounter];
        }
    }

    public void ScrollDownBeard()
    {
        var nextFacialHairs = getNextFacialHair();

        if (facialHairCounter > 0)
        {
            facialHairCounter -= 1;
            facialHair.sprite = nextFacialHairs[facialHairCounter];
        }
        else
        {
            facialHairCounter = nextFacialHair.Length - 1;
            facialHair.sprite = nextFacialHairs[facialHairCounter];
        }
    }

    public Sprite[] getNextFacialHair()
    {
        return nextFacialHair;
    }


    public Sprite[] getNextShirt()
    {
        return nextShirt;
    }

    public void ScrollUpShirt()
    {
        var nextShirt = getNextShirt();

        if (shirtCounter < nextShirt.Length - 1)
        {
            shirtCounter += 1;
            shirt.sprite = nextShirt[shirtCounter];
        }
        else
        {
            shirtCounter = 0;
            shirt.sprite = nextShirt[shirtCounter];
        }
    }

    public void ScrollDownShirt()
    {
        var nextShirt = getNextShirt();

        if (shirtCounter > 0)
        {
            shirtCounter -= 1;
            shirt.sprite = nextShirt[shirtCounter];
        }
        else
        {
            shirtCounter = nextShirt.Length - 1;
            shirt.sprite = nextShirt[shirtCounter];
        }
    }


    public void ScrollUpPants()
    {
        var nextPants = getNextPants();

        if (pantsCounter < nextPants.Length - 1)
        {
            pantsCounter += 1;
            pants.sprite = nextPants[pantsCounter];
        }
        else
        {
            pantsCounter = 0;
            pants.sprite = nextPants[pantsCounter];
        }
    }

    public void ScrollDownPants()
    {
        var nextPants = getNextPants();

        if (pantsCounter > 0)
        {
            pantsCounter -= 1;
            pants.sprite = nextPants[pantsCounter];
        }
        else
        {
            pantsCounter = nextPants.Length - 1;
            pants.sprite = nextPants[pantsCounter];
        }
    }

    public Sprite[] getNextPants()
    {
        return nextPants;
    }

    public void ScrollUpShoes()
    {
        var nextShoes = getNextShoes();

        if (shoesCounter < nextShoes.Length - 1)
        {
            shoesCounter += 1;
            shoes.sprite = nextShoes[shoesCounter];
        }
        else
        {
            shoesCounter = 0;
            shoes.sprite = nextShoes[shoesCounter];
        }
    }

    public void ScrollDownShoes()
    {
        var nextShoes = getNextShoes();

        if (shoesCounter > 0)
        {
            shoesCounter -= 1;
            shoes.sprite = nextShoes[shoesCounter];
        }
        else
        {
            shoesCounter = nextShoes.Length - 1;
            shoes.sprite = nextShoes[shoesCounter];
        }
    }

    public Sprite[] getNextShoes()
    {
        return nextShoes;
    }

    public void ScrollUpEyes()
    {
        var nextEyes = getNextEyes();

        if (eyesCounter < nextEyes.Length - 1)
        {
            eyesCounter += 1;
            eyes.sprite = nextEyes[eyesCounter];
        }
        else
        {
            eyesCounter = 0;
            eyes.sprite = nextEyes[eyesCounter];
        }
    }

    public void ScrollDownEyes()
    {
        var nextEyes = getNextEyes();

        if (eyesCounter > 0)
        {
            eyesCounter -= 1;
            eyes.sprite = nextEyes[eyesCounter];
        }
        else
        {
            eyesCounter = nextEyes.Length - 1;
            eyes.sprite = nextEyes[eyesCounter];
        }
    }

    public Sprite[] getNextEyes()
    {
        return nextEyes;
    }


    //public void IncreaseStrong()
    //{
    //    dataManager.data.strong += 1;
    //    strong.text = dataManager.data.strong.ToString();
    //}

    //public void DecreaseStrong()
    //{
    //    dataManager.data.strong -= 1;
    //    strong.text = dataManager.data.strong.ToString();
    //}

    //public void IncreaseQuick()
    //{
    //    dataManager.data.quick += 1;
    //    quick.text = dataManager.data.quick.ToString();
    //}

    //public void DecreaseQuick()
    //{
    //    dataManager.data.quick -= 1;
    //    quick.text = dataManager.data.quick.ToString();
    //}

    //public void IncreaseSmart()
    //{
    //    dataManager.data.smart += 1;
    //    smart.text = dataManager.data.smart.ToString();
    //}

    //public void DecreaseSmart()
    //{
    //    dataManager.data.smart -= 1;
    //    smart.text = dataManager.data.smart.ToString();
    //}

    //public void IncreaseDevoted()
    //{
    //    dataManager.data.devoted += 1;
    //    devoted.text = dataManager.data.devoted.ToString();
    //}

    //public void DecreaseDevoted()
    //{
    //    dataManager.data.devoted -= 1;
    //    devoted.text = dataManager.data.devoted.ToString();
    //}

    //public void IncreaseTough()
    //{
    //    dataManager.data.tough += 1;
    //    tough.text = dataManager.data.tough.ToString();
    //}

    //public void DecreaseTough()
    //{
    //    dataManager.data.tough -= 1;
    //    tough.text = dataManager.data.tough.ToString();
    //}

    //public void IncreaseCharm()
    //{
    //    dataManager.data.charm += 1;
    //    charm.text = dataManager.data.charm.ToString();
    //}

    //public void DecreaseCharm()
    //{
    //    dataManager.data.charm -= 1;
    //    charm.text = dataManager.data.charm.ToString();
    //}

    public void ChangeName(string text)
    {
        dataManager.data.name = text;
    }

    public void ClickSave()
    {
        dataManager.data.name = playerName.text;
        dataManager.data.hair = hair.sprite.name;
        dataManager.data.facialHair = facialHair.sprite.name;
        dataManager.data.shirt = shirt.sprite.name;
        dataManager.data.shoes = shoes.sprite.name;
        dataManager.data.pants = pants.sprite.name;
        dataManager.data.eyes = eyes.sprite.name;
        dataManager.Save(jsonFile);

        SceneManager.LoadScene("PartyScene");
    }

    public string ThisBtnPressed()
    {
        return PlayerPrefs.GetString("player");
    }

}
