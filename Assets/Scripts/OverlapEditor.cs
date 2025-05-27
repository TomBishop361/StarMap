using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(Overlap))]
public class OverlapEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        Overlap _target = (Overlap)target;  
        
        DrawDefaultInspector();

        if(GUILayout.Button("Print Dictionary"))
        {
            _target.printDictionaryDebug();
        }

    }
}
