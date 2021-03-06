using UnityEditor;
using UnityEngine;

public class MyEditorWindow : EditorWindow
{
    #region 사용이 빈번한 GUI 요소 그룹 사용해보기

    // private int intValue;
    // private float floatValue;
    // private Color colorValue;
    // private Gradient gradientValue = new Gradient();
    // private Vector3 vector3Value;
    // private Vector3Int vector3IntValue;
    // private Rect rectValue;
    // private Object objectValue;
    // private string passwordValue;
    // private string tagValue;
    // private ParticleSystemCollisionType enumValue;
    // private bool toggleValue;
    // private string[] stringArray = new string[] { "String01", "String02", "String03", "String04", "String05", "String06" };
    // private int selectedValue;

    #endregion

    #region Layout System을 이해하자

    // private Vector3 leftScrollPosition;
    // private Vector3 rightScrollPosition;

    #endregion

    #region EditorWindow에 응용

    // private Dictionary<SerializedObject, List<SerializedProperty>> targets = new Dictionary<SerializedObject, List<SerializedProperty>>();
    // private bool isFocused;

    #endregion
    
    #region 타 Editor 훔쳐오기

    // private Editor duplicatedEditor;
    // private Editor[] duplicatedDetailEditor;
    // private List<bool> detailFoldOut = new List<bool>();

    #endregion

    #region 에디터 전용 비휘발성 값 관리하기

    private string stringValue;
    private int intValue;

    #endregion
    
    [MenuItem("MyTool/Open MyTool %g")]
    public static void Open()
    {
        MyEditorWindow window = GetWindow<MyEditorWindow>();
        window.titleContent = new GUIContent("MyTool");
    }

    private void OnGUI()
    {
        #region 기본 GUI 그려보기
        
        // EditorGUILayout.LabelField("LabelField");
        // EditorGUILayout.TextField("TextField");
        // GUILayout.Button("Button");
        
        #endregion

        #region GUI 드로잉 패밀리 살펴보기
        
        // GUI.Label(new Rect(250, 0, 100, 50), "GUI.Label");
        // EditorGUI.LabelField(new Rect(250, 50, 150, 50), "EditorGUI.LabelField");
        // GUILayout.Label("GUILayout.Label");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        
        // GUILayout.Label("GUILayout.Label");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        // GUILayout.Label("GUILayout.Label");
        // GUILayout.Label("GUILayout.Label");
        // GUILayout.Label("GUILayout.Label");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        // EditorGUILayout.LabelField("EditorGUILayout.LabelField");
        
        #endregion

        #region 사용이 빈번한 GUI 요소 그룹 사용해보기

        // intValue = EditorGUILayout.IntField("int 값", intValue);
        // floatValue = EditorGUILayout.FloatField("float 값", floatValue);
        // colorValue = EditorGUILayout.ColorField("Color 값", colorValue);
        // gradientValue = EditorGUILayout.GradientField("Gradient 값", gradientValue);
        // vector3Value = EditorGUILayout.Vector3Field("Vector3 값", vector3Value);
        // vector3IntValue = EditorGUILayout.Vector3IntField("Vector3Int 값", vector3IntValue);
        // rectValue = EditorGUILayout.RectField("Rect 값", rectValue);
        // objectValue = EditorGUILayout.ObjectField("Object 값", objectValue, typeof(Object), false);
        // passwordValue = EditorGUILayout.PasswordField("Password 값", passwordValue);
        // tagValue = EditorGUILayout.TagField("Tag 값", tagValue);
        // EditorGUILayout.Space(15); // 공백
        // enumValue = (ParticleSystemCollisionType)EditorGUILayout.EnumFlagsField("Enum 값", enumValue);
        // floatValue = EditorGUILayout.Slider("Slider 값", floatValue, 0, 100);
        // EditorGUILayout.HelpBox("Help Box", MessageType.Error);
        // toggleValue = EditorGUILayout.Toggle("Toggle 값", toggleValue);
        //
        // EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // 가로 줄 긋기
        //
        // selectedValue = GUILayout.Toolbar(selectedValue, stringArray);
        // GUILayout.Space(15); // 공백
        // selectedValue = GUILayout.SelectionGrid(selectedValue, stringArray, 2);
        //
        // // 텍스처 목록 (https://github.com/halak/unity-editor-icons)
        // GUILayout.Box(EditorGUIUtility.IconContent("Animation.Record"));

        #endregion

        #region Layout System을 이해하자

        // EditorGUILayout.BeginVertical();
        // {
        //     for (int i = 0; i < 3; i++)
        //         EditorGUILayout.LabelField("Label 00");
        // }
        // EditorGUILayout.EndVertical();
        //
        // EditorGUILayout.Space(5);
        //
        // EditorGUILayout.BeginVertical();
        // {
        //     for (int i = 0; i < 3; i++)
        //         EditorGUILayout.LabelField("Label 01");
        // }
        // EditorGUILayout.EndVertical();
        //
        // EditorGUILayout.Space(5);
        //
        // EditorGUILayout.BeginHorizontal();
        // {
        //     for (int i = 0; i < 10; i++)
        //         EditorGUILayout.LabelField("Label 02");
        // }
        // EditorGUILayout.EndHorizontal();
        //
        // EditorGUILayout.BeginHorizontal();
        // {
        //     for (int i = 0; i < 10; i++)
        //         EditorGUILayout.LabelField("Label 03");
        // }
        // EditorGUILayout.EndHorizontal();
        //
        // EditorGUILayout.Space(5);
        //
        // for (int i = 0; i < 5; i++)
        // {
        //     EditorGUILayout.BeginVertical();
        //     {
        //         EditorGUILayout.LabelField($"Title : {i}");
        //
        //         float backUpFieldWidth = EditorGUIUtility.fieldWidth;
        //         float backUpLabelWidth = EditorGUIUtility.labelWidth;
        //
        //         EditorGUIUtility.fieldWidth = 50;
        //         EditorGUIUtility.labelWidth = 50;
        //
        //         EditorGUILayout.BeginHorizontal();
        //         {
        //             for (int j = 0; j < 3; j++)
        //             {
        //                 EditorGUILayout.TextField(j.ToString(), "Put data here");
        //
        //                 bool isLastData = (j == 2);
        //                 if (isLastData == false)
        //                     EditorGUILayout.Space(6);
        //             }
        //         }
        //         EditorGUILayout.EndHorizontal();
        //         
        //         EditorGUIUtility.fieldWidth = backUpFieldWidth;
        //         EditorGUIUtility.labelWidth = backUpLabelWidth;
        //
        //     }
        //     EditorGUILayout.EndVertical();
        //     
        //     EditorGUILayout.Space(10);
        //
        //     if (i < 4)
        //         EditorGUILayout.LabelField("", GUI.skin.horizontalScrollbar);
        // }
        //
        // EditorGUILayout.Space(5);
        //
        // Vector2 offset = new Vector2(20, 20);
        // Rect rectArea = new Rect(offset.x, offset.y, position.width - offset.x * 2, 75);
        //
        // GUILayout.BeginArea(rectArea, GUI.skin.window);
        // {
        //     EditorGUILayout.BeginHorizontal();
        //     {
        //         EditorGUILayout.LabelField("Label Field");
        //         EditorGUILayout.LabelField("Label Field");
        //         EditorGUILayout.LabelField("Label Field");
        //         EditorGUILayout.LabelField("Label Field");
        //     }
        //     EditorGUILayout.EndHorizontal();
        // }
        // GUILayout.EndArea();
        //
        // offset = new Vector2(20, 20);
        // rectArea = new Rect(offset.x, offset.y, position.width - offset.x * 2, 100);
        //
        // GUILayout.BeginArea(rectArea, GUI.skin.window);
        // {
        //     Rect subRect = rectArea;
        //     subRect.Set(0, 0, rectArea.width * 0.5f, rectArea.height);
        //
        //     GUILayout.BeginArea(subRect, "Sub 00", GUI.skin.window);
        //     {
        //         leftScrollPosition = EditorGUILayout.BeginScrollView(leftScrollPosition);
        //         {
        //             EditorGUILayout.BeginVertical();
        //             {
        //                 for (int i = 0; i < 30; i++)
        //                     EditorGUILayout.LabelField($"Label Field {i}");
        //             }
        //             EditorGUILayout.EndVertical();
        //         }
        //         EditorGUILayout.EndScrollView();
        //     }
        //     GUILayout.EndArea();
        //
        //     subRect.x += subRect.width;
        //     GUILayout.BeginArea(subRect, "Sub 01", GUI.skin.window);
        //     {
        //         rightScrollPosition = EditorGUILayout.BeginScrollView(rightScrollPosition);
        //         {
        //             EditorGUILayout.BeginHorizontal();
        //             {
        //                 for (int i = 0; i < 30; i++)
        //                     EditorGUILayout.LabelField($"Label Field {i}");
        //             }
        //             EditorGUILayout.EndHorizontal();
        //         }
        //         EditorGUILayout.EndScrollView();
        //     }
        //     GUILayout.EndArea();
        // }
        // GUILayout.EndArea();
        //
        // using (var scope = new EditorGUILayout.HorizontalScope())
        // {
        //     if (GUI.Button(scope.rect, GUIContent.none))
        //         Debug.Log("Clicked");
        //
        //     for (int i = 0; i < 5; i++)
        //     {
        //         GUILayout.Label("Label");
        //         GUILayout.Box(EditorGUIUtility.FindTexture("BuildSettings.Editor"));
        //     }
        // }
        //
        // using (var scope = new EditorGUILayout.VerticalScope(GUILayout.Width(100)))
        // {
        //     if (GUI.Button(scope.rect, GUIContent.none))
        //         Debug.Log("Clicked");
        //
        //     for (int i = 0; i < 5; i++)
        //     {
        //         GUILayout.Label("Label");
        //         GUILayout.Box(EditorGUIUtility.FindTexture("BuildSettings.Editor"));
        //     }
        // }
        
        #endregion

        #region 같은 GUI도 여러가지 방법으로 그려보자

        // GUIContent myContent = new GUIContent();
        //
        // myContent.text = "textContent";
        // myContent.image = EditorGUIUtility.FindTexture("BuildSettings.Editor");
        //
        // EditorGUILayout.LabelField(myContent);
        //
        // myContent.tooltip = "my tool tip";
        //
        // GUILayout.Button(myContent);
        //
        // GUIStyle myStyle = new GUIStyle();
        //
        // myStyle.fontSize = 15;
        // myStyle.fontStyle = FontStyle.BoldAndItalic;
        // myStyle.normal.textColor = Color.green;
        //
        // GUILayout.Label("Label", myStyle);
        //
        // myStyle = new GUIStyle("button");
        //
        // myStyle.fontSize = 15;
        // myStyle.normal.textColor = Color.red;
        // myStyle.hover = new GUIStyleState() { textColor = Color.green };
        //
        // GUILayout.Button("Button", myStyle);
        //
        // // EditorStyles, GUI.skin, GUI.skin.GetStyle을 이용해서 미리 정의된 스타일을 가져올 수 있음
        // GUILayout.Label("Bold Label", EditorStyles.boldLabel);
        // GUILayout.Box("box", GUI.skin.window);
        //
        // if (GUILayout.Button("Button", GUI.skin.textArea))
        //     Debug.Log("Clicked");
        
        #endregion

        #region OnGUI의 실체 Event

        // Rect area = EditorGUILayout.BeginVertical(GUILayout.Width(200));
        // {
        //     GUI.Box(area, GUIContent.none);
        //     
        //     EditorGUILayout.LabelField("Label Field");
        //     EditorGUILayout.LabelField("Label Field");
        // }
        // EditorGUILayout.EndVertical();
        //
        // if (Event.current.type == EventType.KeyDown)
        // {
        //     if (Event.current.keyCode == KeyCode.Q || Event.current.keyCode == KeyCode.W || Event.current.keyCode == KeyCode.E)
        //         Debug.Log($"'{Event.current.keyCode}' key is down");
        // }
        //
        // if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        //     Debug.Log("Left mouse button is down");
        //
        // if (Event.current.isMouse)
        //     Event.current.Use();
        //
        // if (GUILayout.Button("Try click"))
        //     Debug.LogError("How did you click me?");

        #endregion

        #region EditorWindow에 응용

        // if (GUILayout.Button("Refresh"))
        // {
        //     targets.Clear();
        //
        //     Character[] allCharacters = FindObjectsOfType<Character>();
        //
        //     if (allCharacters != null)
        //     {
        //         foreach (Character character in allCharacters)
        //         {
        //             SerializedObject serializedObject = new SerializedObject(character);
        //             List<SerializedProperty> serializedProperties = new List<SerializedProperty>()
        //             {
        //                 serializedObject.FindProperty(nameof(Character._gameObject)),
        //                 serializedObject.FindProperty(nameof(Character._name)),
        //                 serializedObject.FindProperty(nameof(Character._hp))
        //             };
        //             
        //             targets.Add(serializedObject, serializedProperties);
        //         }
        //     }
        // }
        //
        // foreach (var pair in targets)
        // {
        //     EditorGUI.BeginChangeCheck();
        //     {
        //         EditorGUILayout.LabelField(pair.Key.targetObject.name, EditorStyles.boldLabel);
        //         EditorGUI.indentLevel++;
        //         {
        //             foreach (var property in pair.Value)
        //                 EditorGUILayout.PropertyField(property);
        //         }
        //         EditorGUI.indentLevel--;
        //         
        //         EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        //     }
        //     if (EditorGUI.EndChangeCheck())
        //         pair.Key.ApplyModifiedProperties();
        // }

        #endregion

        #region 에셋 파일 관리 및 조작하는 방법

        // if (GUILayout.Button("모든 Material 찾기"))
        // {
        //     string[] resultGuid = AssetDatabase.FindAssets("t:material");
        //     if (resultGuid != null)
        //     {
        //         foreach (string guid in resultGuid)
        //         {
        //             string path = AssetDatabase.GUIDToAssetPath(guid);
        //             Debug.Log($"GUID : {guid}, Path : {path}, Guid from path : {AssetDatabase.GUIDFromAssetPath(path)}");
        //         }
        //     }
        // }
        //
        // if (GUILayout.Button("모든 Material 로드 및 적용"))
        // {
        //     Renderer[] allRenderers = FindObjectsOfType<Renderer>();
        //     if (allRenderers != null)
        //     {
        //         foreach (Renderer renderer in allRenderers)
        //             DestroyImmediate(renderer.gameObject);
        //     }
        //
        //     string[] resultGuid = AssetDatabase.FindAssets("t:material");
        //     if (resultGuid != null)
        //     {
        //         for (int i = 0; i < resultGuid.Length; i++)
        //         {
        //             string guid = resultGuid[i];
        //             string path = AssetDatabase.GUIDToAssetPath(guid);
        //             
        //             Material loadedMaterial = AssetDatabase.LoadAssetAtPath<Material>(path);
        //             if (loadedMaterial != null)
        //             {
        //                 Debug.Log($"Material Loaded : {path}");
        //                 
        //                 GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //                 cube.transform.position = new Vector3(i * 2, 0, 0);
        //                 cube.GetComponent<Renderer>().material = loadedMaterial;
        //             }
        //         }
        //     }
        // }
        //
        // if (GUILayout.Button("Asset 생성하기"))
        // {
        //     Material loadedMaterial = new Material(Shader.Find("Standard"));
        //     AssetDatabase.CreateAsset(loadedMaterial, $"Assets/Materials/AutoCreatedMaterial{Random.Range(0, 1000)}.mat");
        // }

        #endregion

        #region 타 Editor 훔쳐오기

        // if (Selection.objects != null && Selection.objects.Length == 1)
        // {
        //     Object target = Selection.objects[0];
        //     if (duplicatedEditor == null || duplicatedEditor.name != target.name)
        //     {
        //         duplicatedEditor = Editor.CreateEditor(target);
        //         
        //         GameObject go = target as GameObject;
        //         if (go != null)
        //         {
        //             Component[] allComponents = go.GetComponents(typeof(Component));
        //             if (allComponents != null)
        //             {
        //                 duplicatedDetailEditor = new Editor[allComponents.Length];
        //                 for (int i = 0; i < allComponents.Length; i++)
        //                 {
        //                     detailFoldOut.Add(false);
        //                     duplicatedDetailEditor[i] = Editor.CreateEditor(allComponents[i]);
        //                 }
        //             }
        //         }
        //         else
        //         {
        //             detailFoldOut.Clear();
        //             duplicatedDetailEditor = null;
        //         }
        //     }
        // }
        // else
        // {
        //     duplicatedEditor = null;
        // }
        //
        // if (duplicatedEditor != null)
        // {
        //     duplicatedEditor.DrawHeader();
        //     duplicatedEditor.OnInspectorGUI();
        //
        //     if (duplicatedDetailEditor != null)
        //     {
        //         for (int i = 0; i < duplicatedDetailEditor.Length; i++)
        //         {
        //             detailFoldOut[i] = EditorGUILayout.Foldout(detailFoldOut[i], $"{duplicatedDetailEditor[i].GetType()}");
        //
        //             if (detailFoldOut[i])
        //                 duplicatedDetailEditor[i].OnInspectorGUI();
        //         }
        //     }
        // }

        #endregion

        #region 유저의 오브젝트 선택 직접 제어하기

        // if (GUILayout.Button("Scene에 있는 모든 GameObject 선택하기"))
        // {
        //     GameObject[] targets = FindObjectsOfType<GameObject>(true);
        //     if (targets != null)
        //         Selection.objects = targets;
        // }
        //
        // if (GUILayout.Button("모든 Text 선택하기"))
        // {
        //     Text[] targets = FindObjectsOfType<Text>();
        //     if (targets != null)
        //     {
        //         GameObject[] gameObjects = new GameObject[targets.Length];
        //         for (int i = 0; i < targets.Length; i++)
        //             gameObjects[i] = targets[i].gameObject;
        //         Selection.objects = gameObjects;
        //     }
        // }
        //
        // if (GUILayout.Button("선택한 Object 핑 찍기"))
        // {
        //     if (Selection.objects != null && Selection.objects.Length == 1)
        //         EditorGUIUtility.PingObject(Selection.objects[0]);
        // }

        #endregion

        #region 에디터 전용 비휘발성 값 관리하기

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.PrefixLabel("String");
            stringValue = GUILayout.TextArea(stringValue);
        }
        EditorGUILayout.EndHorizontal();

        intValue = EditorGUILayout.IntField("int", intValue);

        if (GUILayout.Button("값 저장하기"))
        {
            EditorPrefs.SetString("MyStringKey", stringValue);
            EditorPrefs.SetInt("MyIntKey", intValue);
        }

        if (GUILayout.Button("값 로드"))
        {
            stringValue = EditorPrefs.GetString("MyStringKey");
            intValue = EditorPrefs.GetInt("MyIntKey");
        }

        if (GUILayout.Button("값 삭제하기"))
        {
            EditorPrefs.DeleteKey("MyStringKey");
            EditorPrefs.DeleteKey("MyIntKey");
        }

        #endregion
    }
    
    #region EditorWindow에 응용

    // private void Update()
    // {
    //     if (isFocused == false)
    //     {
    //         foreach (var item in targets)
    //             item.Key.Update();
    //         
    //         Repaint();
    //     }
    // }
    //
    // private void OnFocus()
    // {
    //     isFocused = true;
    //
    //     foreach (var item in targets)
    //         item.Key.Update();
    // }
    //
    // private void OnLostFocus()
    // {
    //     isFocused = false;
    // }

    #endregion
}