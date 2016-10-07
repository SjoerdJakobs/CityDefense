using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LoadAndSave))]
public class savedEditor : Editor
{

    public override void OnInspectorGUI()
    {

        LoadAndSave saveInfo = (LoadAndSave)target;
        DrawDefaultInspector();
        //EditorGUILayout.LabelField("castle", saveInfo._Castle.ToString());
        //this.Repaint();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("saveResources"))
        {
            saveInfo.SaveCities();
        }
        if (GUILayout.Button("loadResources"))
        {
            saveInfo.LoadCities();
        }
        GUILayout.EndHorizontal();
    }
}