using UnityEngine;

public class CustomGridPaletteDrawer
{
    public CustomGridPalette palette;
    private Vector2 slotSize = new Vector2(100, 100);
    private Vector2 scrollPosition;
    
    private int selectedIndex = -1;

    public CustomGridPaletteItem SelectedItem
    {
        get
        {
            if (selectedIndex == -1)
                return null;

            return palette.items[selectedIndex];
        }
    }

    public void Draw(Vector2 windowSize)
    {
        if (palette == null || palette.items.Count == 0)
        {
            EditorHelper.DrawLabelCenter(new GUIContent("데이터 없음"), Color.white, 15, FontStyle.Bold);
            return;
        }

        if (selectedIndex == -1)
            selectedIndex = 0;

        scrollPosition = EditorHelper.DrawGridItems(scrollPosition, 10, palette.items.Count, windowSize.x, slotSize, (index) =>
        {
            bool isSelected = CustomGridPaletteItemDrawer.Draw(slotSize, selectedIndex == index, palette.items[index]);

            if (isSelected)
                selectedIndex = index;
        });
    }
}