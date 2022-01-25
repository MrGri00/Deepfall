using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ImplementedTools : MonoBehaviour
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
        string[] sprites = AssetDatabase.FindAssets("t:sprite");

        for (int i = 0; i < sprites.Length; i++)
        {
            AssetDatabase.RenameAsset(AssetDatabase.GUIDToAssetPath(sprites[i]), RenameNoUnderscore(sprites[i]));
        }

        AssetDatabase.SaveAssets();
    }

    static string RenameNoUnderscore(string name)
    {
        string final = "";

        if (name.Length > 1)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!name[i].Equals('_'))
                    final += name[i];
            }

            return final;
        }
        else
            return name;
    }
}
