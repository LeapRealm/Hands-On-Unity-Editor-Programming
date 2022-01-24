using UnityEngine;

public class SceneGUITest : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 200, 200), "This is GUI");
        GUILayout.Label("This is GUILayout");
    }
}