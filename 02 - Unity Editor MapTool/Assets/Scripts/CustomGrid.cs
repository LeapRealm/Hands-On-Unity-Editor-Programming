using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    public CustomGridConfig config;

    public Dictionary<Vector2Int, MapObject> items = new Dictionary<Vector2Int, MapObject>();

    public Vector3[] horizontalLinePointPositions;
    public Vector3[] verticalLinePointPositions;

    public bool reCalculate;

    private void OnValidate()
    {
        reCalculate = true;
    }

    public Vector2Int GetCellCoordinate(Vector3 cellPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(cellPosition.x / config.cellSize.x), Mathf.FloorToInt(cellPosition.y / config.cellSize.y));
    }

    public Vector3 GetCellPosition(Vector2Int cellCoordinate)
    {
        return new Vector3(cellCoordinate.x * config.cellSize.x + config.cellSize.x * 0.5f, cellCoordinate.y * config.cellSize.y + config.cellSize.y * 0.5f, 0);
    }

    public void CalculateLinePoints()
    {
        int horizontalLinePointCount = config.cellCount.y * 2 + 2;
        int verticalLinePointCount = config.cellCount.x * 2 + 2;

        horizontalLinePointPositions = new Vector3[horizontalLinePointCount];
        verticalLinePointPositions = new Vector3[verticalLinePointCount];

        for (int i = 0; i < config.cellCount.x + 1; i++)
        {
            verticalLinePointPositions[i * 2] = new Vector3(i * config.cellSize.x, config.cellSize.y * config.cellCount.y, 0);
            verticalLinePointPositions[i * 2 + 1] = new Vector3(i * config.cellSize.x, 0, 0);
        }

        for (int i = 0; i < config.cellCount.y + 1; i++)
        {
            horizontalLinePointPositions[i * 2] = new Vector3(0, i * config.cellSize.y, 0);
            horizontalLinePointPositions[i * 2 + 1] = new Vector3(config.cellSize.x * config.cellCount.x, i * config.cellSize.y, 0);
        }
    }
    
    public bool Contains(Vector2Int cellCoordinate)
    {
        return cellCoordinate.x >= 0 && cellCoordinate.x < config.cellCount.x && 
               cellCoordinate.y >= 0 && cellCoordinate.y < config.cellCount.y;
    }

    public bool IsItemExist(Vector2Int cellCoordinate)
    {
        return items.ContainsKey(cellCoordinate);
    }

    public MapObject GetItem(Vector2Int cellCoordinate)
    {
        if (items.ContainsKey(cellCoordinate) == false)
            return null;
        
        return items[cellCoordinate];
    }

    public MapObject AddItem(Vector2Int cellCoordinate, CustomGridPaletteItem paletteItem)
    {
        if (items.ContainsKey(cellCoordinate))
        {
            Debug.LogError("아이템이 이미 존재합니다. 먼저 삭제한 후 다시 시도하세요.");
            return null;
        }

        GameObject target = Instantiate(paletteItem.itemGameObject, transform);
        target.transform.position = GetCellPosition(cellCoordinate);
        MapObject targetMapObject = target.AddComponent<MapObject>();
        targetMapObject.id = paletteItem.id;
        targetMapObject.cellCoordinate = cellCoordinate;

        items.Add(cellCoordinate, targetMapObject);

        return targetMapObject;
    }

    public void RemoveItem(Vector2Int cellCoordinate)
    {
        if (items.ContainsKey(cellCoordinate))
            items.Remove(cellCoordinate);
    }

    public byte[] Serialize()
    {
        byte[] buffer = null;
        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (BinaryWriter writer = new BinaryWriter(memoryStream))
            {
                writer.Write(items.Count);

                foreach (var item in items)
                {
                    writer.Write(item.Key.x);
                    writer.Write(item.Key.y);
                    writer.Write(item.Value.id);
                }

                buffer = memoryStream.ToArray();
            }
        }

        return buffer;
    }

    public void Deserialize(byte[] buffer, CustomGridPalette palette)
    {
        foreach (var item in items)
            DestroyImmediate(item.Value.gameObject);
        
        items.Clear();

        using (MemoryStream memoryStream = new MemoryStream(buffer))
        {
            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                int count = reader.ReadInt32();

                for (int i = 0; i < count; i++)
                {
                    int xCoordinate = reader.ReadInt32();
                    int yCoordinate = reader.ReadInt32();
                    int id = reader.ReadInt32();

                    Vector2Int coordinate = new Vector2Int(xCoordinate, yCoordinate);
                    AddItem(coordinate, palette.GetItem(id));
                }
            }
        }
    }
}