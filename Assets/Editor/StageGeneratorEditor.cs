using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StageGenerator))]
public class StageGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var generator = (StageGenerator)target;
        if (GUILayout.Button("マップ生成"))
        {
            generator.GenerateMap();
        }
    }
}
