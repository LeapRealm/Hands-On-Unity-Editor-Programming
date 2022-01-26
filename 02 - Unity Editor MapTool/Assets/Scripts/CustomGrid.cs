using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    public CustomGridConfig config;

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
}