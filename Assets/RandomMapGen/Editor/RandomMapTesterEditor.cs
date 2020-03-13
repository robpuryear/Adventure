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


        if (GUILayout.Button("Start Battle"))
        {
            // make sure the game is running before we try to make a map
            if (Application.isPlaying)
            {
                script.StartBattle();
            }
        }

        if (GUILayout.Button("End Battle"))
        {
            // make sure the game is running before we try to make a map
            if (Application.isPlaying)
            {
                script.EndBattle();
            }
        }

        if (GUILayout.Button("Reset"))
        {
            // make sure the game is running before we try to make a map
            if (Application.isPlaying)
            {
                script.Reset();
            }
        }
    }
}
