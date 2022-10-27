using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovingCube)), CanEditMultipleObjects]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MovingCube movingCube = (MovingCube)target;
        EditorGUILayout.LabelField("MovingCube Settings", EditorStyles.boldLabel);
        if (GUILayout.Button("Set Position 2"))
        {
            movingCube.startPos2 = movingCube.transform.position;
        }
        if (GUILayout.Button("Set Position 1"))
        {
            movingCube.startPos1 = movingCube.transform.position;
        }
    }
}
