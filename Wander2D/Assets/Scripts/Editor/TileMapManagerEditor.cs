using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileMapManager))]
public class TileMapManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var script = (TileMapManager) target;

        if(GUILayout.Button("Save Map")){
            script.SaveMap();
        }

        if(GUILayout.Button("Clear Map")){
            script.ClearMap();
        }

        if(GUILayout.Button("Load Map")){
            script.LoadMap();
        }
    }
}
