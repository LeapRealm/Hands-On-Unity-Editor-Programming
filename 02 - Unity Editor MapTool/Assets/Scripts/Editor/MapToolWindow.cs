using System.IO;
using UnityEditor;
using UnityEngine;

public enum Mode
{
    None = 0,
    Create,
    Edit
}

public enum EditToolMode
{
    Paint,
    Erase
}

public class MapToolWindow : EditorWindow
{
    private Mode currentMode = Mode.None;

    private EditToolMode selectedEditToolMode = EditToolMode.Paint;
    private GUIContent[] editToolModeContents;

    public CustomGridPalette palette;
    public CustomGridPaletteDrawer paletteDrawer = new CustomGridPaletteDrawer();

    private Vector2Int cellCount;
    private Vector2 cellSize;

    private CustomGrid grid;
    
    private bool IsCreatable => cellCount.x > 0 && cellCount.y > 0 && cellSize.x > 0 && cellSize.y > 0 && palette != null;
    
    [MenuItem("Tools/Open MapTool %q")]
    public static void Open()
    {
        MapToolWindow window = GetWindow<MapToolWindow>();
        window.titleContent = new GUIContent("MapTool");
    }

    private void OnEnable()
    {
        editToolModeContents = new GUIContent[]
        {
            EditorGUIUtility.TrIconContent("Grid.PaintTool", "그리기 모드"),
            EditorGUIUtility.TrIconContent("Grid.EraserTool", "지우기 모드")
        };
        
        ChangeMode(Mode.Create);

        SceneView.duringSceneGui -= OnSceneGui;
        SceneView.duringSceneGui += OnSceneGui;

        Undo.undoRedoPerformed -= OnUndoRedoPerformed;
        Undo.undoRedoPerformed += OnUndoRedoPerformed;
    }

    private void OnUndoRedoPerformed()
    {
        grid.RefreshItems();
    }

    private void OnDisable()
    {
        ClearAll();
        SceneView.duringSceneGui -= OnSceneGui;
        Undo.undoRedoPerformed -= OnUndoRedoPerformed;
    }

    private void Update()
    {
        SceneView.lastActiveSceneView.Repaint();
    }

    private void OnSceneGui(SceneView sceneView)
    {
        if (currentMode != Mode.Edit)
            return;
        
        Vector2 mousePosition = Event.current.mousePosition;
        Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
        EditorHelper.Raycast(ray.origin, ray.origin + ray.direction * 300, out Vector3 hitPosition);
        Vector2Int cellCoordinate = grid.GetCellCoordinate(hitPosition);

        if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
        {
            if (grid.Contains(cellCoordinate))
            {
                switch (selectedEditToolMode)
                {
                    case EditToolMode.Paint:
                        Paint(cellCoordinate);
                        break;
                    case EditToolMode.Erase:
                        Erase(cellCoordinate);
                        break;
                }
                Event.current.Use();
            }
        }
        
        Handles.BeginGUI();
        {
            GUI.Label(new Rect(mousePosition.x, mousePosition.y + 10, 100, 50), cellCoordinate.ToString(), EditorStyles.boldLabel);

            if (grid.IsItemExist(cellCoordinate))
            {
                CustomGridPaletteItem item = palette.GetItem(grid.GetItem(cellCoordinate).id);
                Texture2D previewTexture = AssetPreview.GetAssetPreview(item.itemPrefab);

                Rect rectBox = new Rect(10, 10, previewTexture.width + 10, previewTexture.height + 10);
                Rect rectTexture = new Rect(15, 15, previewTexture.width, previewTexture.height);
                Rect rectName = new Rect(rectBox.center.x - 25, rectBox.yMax - 25, 100, 10);
                
                GUI.Box(rectBox, GUIContent.none, GUI.skin.window);
                GUI.DrawTexture(rectTexture, previewTexture);
                GUI.Label(rectName, item.name, EditorStyles.boldLabel);
            }
        }
        Handles.EndGUI();
    }

    private void Paint(Vector2Int cellCoordinate)
    {
        CustomGridPaletteItem selectedItem = paletteDrawer.SelectedItem;
        if (selectedItem == null)
            return;

        Erase(cellCoordinate);

        MapObject target = grid.AddItem(cellCoordinate, selectedItem);
        Undo.RegisterCreatedObjectUndo(target.gameObject, "Create MapObject");
    }
    
    private void Erase(Vector2Int cellCoordinate)
    {
        if (grid.IsItemExist(cellCoordinate))
        {
            Undo.DestroyObjectImmediate(grid.GetItem(cellCoordinate).gameObject);
            grid.RemoveItem(cellCoordinate);
        }
    }

    private void OnGUI()
    {
        switch (currentMode)
        {
            case Mode.Create:
                DrawCreateMode();
                break;
            
            case Mode.Edit:
                if (Event.current.keyCode == KeyCode.Q && Event.current.type == EventType.KeyDown)
                {
                    selectedEditToolMode = EditToolMode.Paint;
                    Repaint();
                    Event.current.Use();
                }
                else if (Event.current.keyCode == KeyCode.W && Event.current.type == EventType.KeyDown)
                {
                    selectedEditToolMode = EditToolMode.Erase;
                    Repaint();
                    Event.current.Use();
                }
                
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
            
            palette = (CustomGridPalette)EditorGUILayout.ObjectField("팔레트", palette, typeof(CustomGridPalette), false);
            paletteDrawer.palette = palette;
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
        ClearAll();

        CustomGrid grid = new GameObject("Grid").AddComponent<CustomGrid>();
        grid.config = new CustomGridConfig();
        grid.config.cellCount = cellCount;
        grid.config.cellSize = cellSize;
        return grid;
    }

    private void DrawEditMode()
    {
        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        {
            if (GUILayout.Button("생성 모드", EditorStyles.toolbarButton))
            {
                ClearAll();
                ChangeMode(Mode.Create);
            }
            
            GUILayout.FlexibleSpace();
            
            if (GUILayout.Button("불러오기", EditorStyles.toolbarButton))
            {
                Load();
            }
            
            if (GUILayout.Button("저장하기", EditorStyles.toolbarButton))
            {
                Save();
            }
        }
        GUILayout.EndHorizontal();
        
        EditorHelper.DrawLabelCenter(new GUIContent("편집 모드"), Color.white, 20, FontStyle.Bold);
        
        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            selectedEditToolMode = (EditToolMode)GUILayout.Toolbar((int)selectedEditToolMode, editToolModeContents, "LargeButton", GUILayout.Width(100), GUILayout.Height(40));
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();

        Rect lastRect = GUILayoutUtility.GetLastRect();
        Rect area = new Rect(0, lastRect.yMax, position.width, position.height - lastRect.yMax - 1);
        
        GUI.Box(area, GUIContent.none, GUI.skin.window);
        
        paletteDrawer.Draw(new Vector2(position.width, position.height));
    }

    public void Save()
    {
        string path = EditorUtility.SaveFilePanel("맵 데이터 저장", Application.dataPath, "MapData.bin", "bin");

        if (string.IsNullOrEmpty(path) == false)
        {
            byte[] buffer = grid.Serialize();
            File.WriteAllBytes(path, buffer);
            
            ShowNotification(new GUIContent("저장 성공!"), 3);
        }
    }

    public void Load()
    {
        string path = EditorUtility.OpenFilePanel("맵 데이터 불러오기", Application.dataPath, "bin");

        if (string.IsNullOrEmpty(path) == false)
        {
            byte[] buffer = File.ReadAllBytes(path);
            grid.Deserialize(buffer, palette);
        }
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
                SceneView.lastActiveSceneView.in2DMode = true;
                Debug.Log("Changed to Edit Mode!");
                break;
        }

        currentMode = newMode;
    }

    private void ClearAll()
    {
        CustomGrid[] existGrids = FindObjectsOfType<CustomGrid>();

        if (existGrids != null)
        {
            foreach (CustomGrid existGrid in existGrids)
                DestroyImmediate(existGrid.gameObject);
        }

        grid = null;
    }
}