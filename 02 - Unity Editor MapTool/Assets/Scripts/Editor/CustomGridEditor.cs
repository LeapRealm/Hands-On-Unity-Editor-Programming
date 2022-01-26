using UnityEditor;

[CustomEditor(typeof(CustomGrid))]
public class CustomGridEditor : Editor
{
    [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
    public static void DrawHandles(CustomGrid customGrid, GizmoType gizmoType)
    {
        if (customGrid.reCalculate)
        {
            customGrid.CalculateLinePoints();
            customGrid.reCalculate = false;
        }
        
        Handles.DrawLines(customGrid.horizontalLinePointPositions);
        Handles.DrawLines(customGrid.verticalLinePointPositions);
    }
}