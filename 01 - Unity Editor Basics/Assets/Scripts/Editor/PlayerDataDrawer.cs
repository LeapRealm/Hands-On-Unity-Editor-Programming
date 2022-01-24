using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PlayerData))]
public class PlayerDataDrawer : PropertyDrawer
{
    // PropertyDrawer::OnGUI에서는 Layout류의 자동 레이아웃 클래스를 사용할 수 없음
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.Box(position, GUIContent.none, GUI.skin.window);

        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        {
            EditorGUI.indentLevel++;
            {
                Rect rect = new Rect(position.x, position.y + GUIStyle.none.CalcSize(label).y + 2, position.width, 16);

                foreach (SerializedProperty prop in property)
                {
                    GUI.color = new Color(Random.value, Random.value, Random.value);
                    EditorGUI.PropertyField(rect, prop);
                    rect.y += 18;
                }
            
                GUI.color = Color.white;
            }
            EditorGUI.indentLevel--;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int count = 0;
        
        foreach (SerializedProperty prop in property)
            count++;

        return EditorGUIUtility.singleLineHeight * (count + 1) + 6;
    }
}