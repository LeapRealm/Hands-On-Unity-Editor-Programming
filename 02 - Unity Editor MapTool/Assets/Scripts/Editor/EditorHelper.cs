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

    public static void Raycast(Vector3 rayOriginalPosition, Vector3 rayDestinationPosition, out Vector3 hitPosition)
    {
        Vector3 planePosition01 = Vector3.up;
        Vector3 planePosition02 = Vector3.right;
        Vector3 planePosition03 = Vector3.down;

        Vector3 planeDirection = Vector3.Cross((planePosition02 - planePosition01).normalized, (planePosition03 - planePosition01).normalized);
        Vector3 lineDirection = (rayDestinationPosition - rayOriginalPosition).normalized;

        float dotLinePlane = Vector3.Dot(lineDirection, planeDirection);
        float t = Vector3.Dot(planePosition01 - rayOriginalPosition, planeDirection) / dotLinePlane;

        hitPosition = rayOriginalPosition + (lineDirection * t);
    }
}