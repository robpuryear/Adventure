# Character JSON

On Edit Character scene, the JSON file gets saved after clicking the Done button. 

The JSON file on windows is located at C://Users/“username”/AppData/LocalLow/“YourCompany”/“ProjectName”/player1.txt

The JSON file on Mac is located at ~/Library/Application Support/DefaultCompany/AdventureSaga/player1.txt

It has the following structure for example:

```
{
  "name": "Player1",
  "strong": 85,
  "quick": 84,
  "smart": 83,
  "devoted": 82,
  "tough": 81,
  "charm": 80,
  "hair": "base-man-hair1",
  "facialHair": "base-man-facial-hair1",
  "shirt": "base-man-shirt1",
  "pants": "base-man-pants1",
  "shoes": "base-man-shoes1"
}
```

The player attributes from "name" to "charm" can all be set on the Character Edit screen or manually edited in this JSON file.

The attributes from "hair" to "shoes" have a value of the image name. There has to be a corresponding image located in the Unity directory `Resources/Art`


# Story JSON

In the `Resources/States` directory, we control the states with the following example JSON file:

```
{
    "storyText": "The Adventure Begins - The clues have led you directly to a cave in the foothills of the Greypeak Mountains. Outside the opening are a variety of tracks and prints.",
    "storyImage": "Art/cave 1",
    "btn1Text": "Investigate",
    "btn2Text": "",
    "btn3Text": "Ignore",
    "states": [
        {
            "btn1": "investigateCave",
            "btn2": "",
            "btn3": "Ignore"
        }
    ]
}
```

`storyText`   - the text that will be displayed at the top of the panel
`storyImage`  - the image to be loaded. It must be `Art/"imageName"`
`btn1Text`    - the text on the button on the left
`btn2Text`    - the text on the button in the middle
`btn3Text`    - the text on the button on the right
`states`      - an array that holds the states that each button when pressed when go into. The value is the name of the json file of the state you want to go into. For example, using the above example, if button 1 is pressed, the json file named `investigateCave` will load. That filename will need to be in the `Resources/States` directory.

If `btn1Text`, `btn2Text`, or `btn3Text` are an empty string, the button will be hidden