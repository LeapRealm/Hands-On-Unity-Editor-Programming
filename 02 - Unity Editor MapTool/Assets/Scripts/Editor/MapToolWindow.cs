using UnityEditor;
using UnityEngine;

public enum Mode
{
    None = 0,
    Create,
    Edit
}

public class MapToolWindow : EditorWindow
{
    private Mode currentMode = Mode.None;
    private bool IsCreatable => false;
    
    [MenuItem("Tools/Open MapTool %q")]
    public static void Open()
    {
        MapToolWindow window = GetWindow<MapToolWindow>();
        window.titleContent = new GUIContent("MapTool");
    }

    private void OnEnable()
    {
        ChangeMode(Mode.Create);
    }

    private void OnDisable()
    {
        
    }

    private void OnGUI()
    {
        switch (currentMode)
        {
            case Mode.Create:
                DrawCreateMode();
                break;
            
            case Mode.Edit:
                DrawEditMode();
                break;
        }
    }

    private void DrawCreateMode()
    {
        EditorHelper.DrawLabelCenter(new GUIContent("생성 모드"), Color.white, 20, FontStyle.Bold);

        using (var scope = new GUILayout.VerticalScope(GUI.skin.window))
        {
            
        }

        GUI.enabled = IsCreatable;
        if (EditorHelper.DrawButtonCenter("생성하기", new Vector2(80, 30)))
        {
            Debug.Log("Create!");
        }
        GUI.enabled = true;
    }

    private void DrawEditMode()
    {
        EditorGUILayout.LabelField("편집 모드");
    }

    private void ChangeMode(Mode newMode)
    {
        if (currentMode == newMode)
            return;

        switch (newMode)
        {
            case Mode.Create:
                Debug.Log("Changed to Create Mode!");
                break;
            
            case Mode.Edit:
                Debug.Log("Changed to Edit Mode!");
                break;
        }

        currentMode = newMode;
    }
}