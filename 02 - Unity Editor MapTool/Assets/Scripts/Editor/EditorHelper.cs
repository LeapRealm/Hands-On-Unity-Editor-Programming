using UnityEngine;

public static class EditorHelper
{
    public static void DrawLabelCenter(GUIContent content, Color fontColor, int fontSize, FontStyle fontStyle)
    {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.normal.textColor = fontColor;
        guiStyle.fontSize = fontSize;
        guiStyle.fontStyle = fontStyle;
        guiStyle.padding.top = 10;
        guiStyle.padding.bottom = 10;
        
        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            GUILayout.Label(content, guiStyle);
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();
    }

    public static bool DrawButtonCenter(string text, Vector2 size)
    {
        bool clicked;
        
        GUILayout.Space(5);
        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            clicked = GUILayout.Button(text, GUILayout.Width(size.x), GUILayout.Height(size.y));
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(5);

        return clicked;
    }
}