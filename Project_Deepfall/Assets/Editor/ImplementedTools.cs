using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ImplementedTools : Editor
{
    [MenuItem("ImplementedTools/Toggle Active &#t", false, 1)] // & = alt, # = shift, t
    public static void ToggleActive()
    {
        Transform[] selectedElements = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (selectedElements.Length > 0)
        {
            for (int i = 0; i < selectedElements.Length; i++)
            {
                selectedElements[i].gameObject.SetActive(!selectedElements[i].gameObject.activeSelf);
            }
        }
        else
            EditorUtility.DisplayDialog("Error", "You must select at least one (1) element in the scene", "Ok");
    }

    [MenuItem("ImplementedTools/Sprites Auto Name Format &#r", false, 1)] // & = alt, # = shift, r
    public static void SpritesAutoNameFormat()
    {
        string[] sprites = AssetDatabase.FindAssets("t:sprite", null);

        for (int i = 0; i < sprites.Length; i++)
        {
            //AssetDatabase.RenameAsset(AssetDatabase.GUIDToAssetPath(sprites[i]), RenameNoUnderscore(sprites[i]));

            //Debug.Log(AssetDatabase.TryGetGUIDAndLocalFileIdentifier<>);
        }

        //AssetDatabase.SaveAssets();
    }

    static string RenameNoUnderscore(string name)
    {
        string final = "";

        if (name.Length > 1)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] != '_')
                    final += name[i];
            }

            return final;
        }
        else
            return name;
    }

    [MenuItem("ImplementedTools/Rename Test", false, 1)]
    public static void RenameTest()
    {
        string a = "Hola_Que_Tal";

        EditorUtility.DisplayDialog("Test 1", a, "Ok");

        a = RenameNoUnderscore(a);

        EditorUtility.DisplayDialog("Test 2", a, "Ok");
    }
}
