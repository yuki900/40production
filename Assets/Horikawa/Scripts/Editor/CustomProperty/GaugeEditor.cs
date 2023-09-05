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

        // �^�[�Q�b�g
        Gauge targetGauge = (Gauge)target;

        // �C���X�y�N�^�Ƀt�B�[���h��\�����Ēl�𔽉f
        targetGauge.Value = EditorGUILayout.Slider("Value", targetGauge.Value, 0f, 1.0f);

        serializedObject.ApplyModifiedProperties();
    }
}
