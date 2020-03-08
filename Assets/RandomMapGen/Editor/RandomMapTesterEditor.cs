using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomMapTester))]

public class RandomMapTesterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        // get a reference to the RandomMapTester object
        var script = (RandomMapTester)target;

        // create a button to run the function to create a map
        if(GUILayout.Button("Generate Island"))
        {
            // make sure the game is running before we try to make a map
            if (Application.isPlaying)
            {
                script.MakeMap();
            }
        }

        // create a button to run the function to create a player
        if (GUILayout.Button("Create Player"))
        {
            // make sure the game is running before we try to make a map
            if (Application.isPlaying)
            {
                script.CreatePlayer();
            }
        }

        if(GUILayout.Button("Reset"))
        {
            // make sure the game is running before we try to make a map
            if (Application.isPlaying)
            {
                script.Reset();
            }
        }
    }
}
