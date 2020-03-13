﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class AssetUtil
{

	public static void CreateScriptableObject<T>() where T : ScriptableObject
	{

		var asset = ScriptableObject.CreateInstance<T>();

		var path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (path == "")
        {
            path = "Assets";
        }
        var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New" + typeof(T) + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);
        Selection.activeObject = asset;
        EditorUtility.FocusProjectWindow();
        AssetDatabase.SaveAssets();

    }

}
