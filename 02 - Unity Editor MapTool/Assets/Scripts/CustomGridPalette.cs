using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Grid/Create Palette")]
public class CustomGridPalette : ScriptableObject
{
    public List<CustomGridPaletteItem> items;

    public CustomGridPaletteItem GetItem(int id)
    {
        return items.Find(i => i.id == id);
    }
}