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

# Battle System

To test the pokemon style battle game, open the scene from Assets > BattleSystem > Scenes > BattleSystemScene