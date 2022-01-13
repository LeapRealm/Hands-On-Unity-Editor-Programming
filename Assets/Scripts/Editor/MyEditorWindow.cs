using UnityEditor;
using UnityEngine;

public class MyEditorWindow : EditorWindow
{
    private int intValue;
    private float floatValue;
    private Color colorValue;
    private Gradient gradientValue = new Gradient();
    private Vector3 vector3Value;
    private Vector3Int vector3IntValue;
    private Rect rectValue;
    private Object objectValue;
    private string passwordValue;
    private string tagValue;
    private ParticleSystemCollisionType enumValue;
    private bool toggleValue;
    private string[] stringArray = new string[] { "String01", "String02", "String03", "String04", "String05", "String06" };
    private int selectedValue;
    
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

        intValue = EditorGUILayout.IntField("int 값", intValue);
        floatValue = EditorGUILayout.FloatField("float 값", floatValue);
        colorValue = EditorGUILayout.ColorField("Color 값", colorValue);
        gradientValue = EditorGUILayout.GradientField("Gradient 값", gradientValue);
        vector3Value = EditorGUILayout.Vector3Field("Vector3 값", vector3Value);
        vector3IntValue = EditorGUILayout.Vector3IntField("Vector3Int 값", vector3IntValue);
        rectValue = EditorGUILayout.RectField("Rect 값", rectValue);
        objectValue = EditorGUILayout.ObjectField("Object 값", objectValue, typeof(Object), false);
        passwordValue = EditorGUILayout.PasswordField("Password 값", passwordValue);
        tagValue = EditorGUILayout.TagField("Tag 값", tagValue);
        EditorGUILayout.Space(15); // 공백
        enumValue = (ParticleSystemCollisionType)EditorGUILayout.EnumFlagsField("Enum 값", enumValue);
        floatValue = EditorGUILayout.Slider("Slider 값", floatValue, 0, 100);
        EditorGUILayout.HelpBox("Help Box", MessageType.Error);
        toggleValue = EditorGUILayout.Toggle("Toggle 값", toggleValue);
        
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // 가로 줄 긋기
        
        selectedValue = GUILayout.Toolbar(selectedValue, stringArray);
        GUILayout.Space(15); // 공백
        selectedValue = GUILayout.SelectionGrid(selectedValue, stringArray, 2);

        // 텍스처 목록 (https://github.com/halak/unity-editor-icons)
        GUILayout.Box(EditorGUIUtility.IconContent("Animation.Record"));

        #endregion
    }
}