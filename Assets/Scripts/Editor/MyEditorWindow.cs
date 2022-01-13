using System;
using UnityEditor;
using UnityEngine;

public class MyEditorWindow : EditorWindow
{
    [MenuItem("MyTool/Open MyTool %g")]
    public static void Open()
    {
        MyEditorWindow window = GetWindow<MyEditorWindow>();
        window.titleContent = new GUIContent("MyTool");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("LabelField");
        EditorGUILayout.TextField("TextField");
        GUILayout.Button("Button");
    }
}