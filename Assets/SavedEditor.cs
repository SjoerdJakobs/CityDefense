using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Saved))]
public class savedEditor : Editor
{

    public override void OnInspectorGUI()
    {

        Saved saveInfo = (Saved)target;
        DrawDefaultInspector();
        //EditorGUILayout.LabelField("castle", saveInfo._Castle.ToString());
        //this.Repaint();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("saveResources"))
        {
            saveInfo.saveResource();
        }
        if (GUILayout.Button("loadResources"))
        {
            saveInfo.loadResource();
        }
        GUILayout.EndHorizontal();
    }
}