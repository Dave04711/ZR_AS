using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AgentSpawn)), CanEditMultipleObjects]
public class AgentSpawnInspector : Editor
{
    public override void OnInspectorGUI()
    {
        AgentSpawn script = (AgentSpawn) target;

        DrawDefaultInspector();

        if (GUILayout.Button("Spawn Agent"))
        {
            script.SpawnAgent_Editor();
        }
    }
}