using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Gauge))]
public class GaugeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // ターゲット
        Gauge targetGauge = (Gauge)target;

        // インスペクタにフィールドを表示して値を反映
        targetGauge.Value = EditorGUILayout.Slider("Value", targetGauge.Value, 0f, 1.0f);

        serializedObject.ApplyModifiedProperties();
    }
}
