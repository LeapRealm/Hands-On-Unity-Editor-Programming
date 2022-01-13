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
        #region 기본 GUI 그려보기
        
        // EditorGUILayout.LabelField("LabelField");
        // EditorGUILayout.TextField("TextField");
        // GUILayout.Button("Button");
        
        #endregion

        #region GUI 드로잉 패밀리 살펴보기
        
        // GUI.Label(new Rect(250, 0, 100, 50), "GUI.Label");
        // EditorGUI.LabelField(new Rect(250, 50, 150, 50), "EditorGUI.LabelField");
        //
        // GUILayout.Label("GUILayout.Label");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        
        // GUILayout.Label("GUILayout.Label");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        // GUILayout.Label("GUILayout.Label");
        // GUILayout.Label("GUILayout.Label");
        // GUILayout.Label("GUILayout.Label");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        
        #endregion
        
        
    }
}