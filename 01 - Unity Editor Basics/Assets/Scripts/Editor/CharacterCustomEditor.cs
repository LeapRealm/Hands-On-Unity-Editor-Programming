using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Character))]
public class CharacterCustomEditor : Editor
{
    private Character _character;

    private SerializedProperty _gameObject;
    private SerializedProperty _name;
    private SerializedProperty _hp;

    private void OnEnable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.duringSceneGui += OnSceneGUI;
        
        _gameObject = serializedObject.FindProperty(nameof(Character._gameObject));
        _name = serializedObject.FindProperty(nameof(Character._name));
        _hp = serializedObject.FindProperty(nameof(Character._hp));

        _character = (Character)target;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        if (_hp.intValue < 500)
            GUI.color = Color.red;
        else
            GUI.color = Color.green;

        _hp.intValue = EditorGUILayout.IntSlider("HP 값", _hp.intValue, 0, 1000);

        EditorGUILayout.BeginHorizontal();
        {
            GUI.color = Color.blue;
            EditorGUILayout.PrefixLabel("이름");
            GUI.color = Color.white;
            _name.stringValue = EditorGUILayout.TextArea(_name.stringValue);
        }
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.PropertyField(_gameObject);
        
        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        Handles.Label(_character.transform.position, $"{_character.gameObject.name}");

        Character[] characters = FindObjectsOfType<Character>();

        foreach (Character character in characters)
        {
            if (_character != character)
            {
                Vector3 otherPosition = character.transform.position;
                Handles.DrawLine(_character.transform.position, otherPosition);
                
                Handles.color = Color.red;
                Handles.DrawWireCube(otherPosition, Vector3.one);
                Handles.color = Color.white;
            }
        }

        Handles.DrawWireCube(_character.transform.position, new Vector3(2, 3, 2));

        Handles.BeginGUI();
        {
            if (GUILayout.Button("Move Right"))
                _character.transform.position += new Vector3(1, 0, 0);

            if (GUILayout.Button("Move Left"))
                _character.transform.position += new Vector3(-1, 0, 0);
        }
        Handles.EndGUI();
    }
}