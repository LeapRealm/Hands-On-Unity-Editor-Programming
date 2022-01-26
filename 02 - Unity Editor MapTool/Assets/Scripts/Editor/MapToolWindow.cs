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

    public Vector2Int cellCount;
    public Vector2 cellSize;

    public CustomGrid grid;
    
    private bool IsCreatable => cellCount.x > 0 && cellCount.y > 0 && cellSize.x > 0 && cellSize.y > 0;
    
    [MenuItem("Tools/Open MapTool %q")]
    public static void Open()
    {
        MapToolWindow window = GetWindow<MapToolWindow>();
        window.titleContent = new GUIContent("MapTool");
    }

    private void OnEnable()
    {
        ChangeMode(Mode.Create);

        SceneView.duringSceneGui -= OnSceneGui;
        SceneView.duringSceneGui += OnSceneGui;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGui;
    }
    
    private void OnSceneGui(SceneView sceneView)
    {
        Vector2 currentMousePosition = Event.current.mousePosition;
        Ray ray = HandleUtility.GUIPointToWorldRay(currentMousePosition);
        
        EditorHelper.Raycast(ray.origin, ray.origin + ray.direction * 300, out Vector3 hitPosition);
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
            cellCount = EditorGUILayout.Vector2IntField("Cell 개수", cellCount);
            cellSize = EditorGUILayout.Vector2Field("Cell 크기", cellSize);
        }

        GUI.enabled = IsCreatable;
        if (EditorHelper.DrawButtonCenter("생성하기", new Vector2(80, 30)))
        {
            grid = BuildGrid(cellCount, cellSize);
            
            ChangeMode(Mode.Edit);
        }
        GUI.enabled = true;
    }

    private CustomGrid BuildGrid(Vector2Int cellCount, Vector2 cellSize)
    {
        CustomGrid[] existGrids = FindObjectsOfType<CustomGrid>();

        if (existGrids != null)
        {
            foreach (CustomGrid existGrid in existGrids)
                DestroyImmediate(existGrid.gameObject);
        }

        CustomGrid grid = new GameObject("Grid").AddComponent<CustomGrid>();
        grid.config = new CustomGridConfig();
        grid.config.cellCount = cellCount;
        grid.config.cellSize = cellSize;
        return grid;
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