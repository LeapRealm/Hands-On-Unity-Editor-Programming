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
        _gameObject = serializedObject.FindProperty(nameof(Character._gameObject));
        _name = serializedObject.FindProperty(nameof(Character._name));
        _hp = serializedObject.FindProperty(nameof(Character._hp));

        _character = (Character)target;
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
}