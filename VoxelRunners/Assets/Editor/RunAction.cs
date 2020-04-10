using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(MMenu))]
public class RunAction : Editor {
    public override void OnInspectorGUI() {


        //EditorGUILayout.BeginHorizontal();
        //EditorGUILayout.LabelField("A fresh start!!!");
        //EditorGUILayout.EndHorizontal();

        DrawDefaultInspector();

        MMenu theMenu = (MMenu)target;


        EditorGUILayout.Space();

        theMenu.camSpeed = EditorGUILayout.Slider("Camera Speed: ", theMenu.camSpeed, 0, 10);

        EditorGUILayout.Space();

        if (GUILayout.Button("Reset Characters")) {
            theMenu.ResetCharacters();
        }

    }
}
