using UnityEditor;
using UnityEngine;

public class CustomGridPaletteItemDrawer
{
    public static bool Draw(Vector2 slotSize, bool isSelected, CustomGridPaletteItem item)
    {
        Rect area = GUILayoutUtility.GetRect(slotSize.x, slotSize.y, GUIStyle.none, GUILayout.MaxWidth(slotSize.x), GUILayout.MaxHeight(slotSize.y));

        bool selected = GUI.Button(area, AssetPreview.GetAssetPreview(item.itemPrefab));
        GUI.Label(new Rect(area.center.x, area.center.y, 100, 50), item.name);

        if (isSelected)
        {
            Rect selectMarkArea = area;
            selectMarkArea.x = selectMarkArea.center.x - 30;
            selectMarkArea.width = 30;
            selectMarkArea.height = 30;
            GUI.DrawTexture(selectMarkArea, EditorGUIUtility.FindTexture("d_FilterSelectedOnly@2x"));
        }

        return selected;
    }
}