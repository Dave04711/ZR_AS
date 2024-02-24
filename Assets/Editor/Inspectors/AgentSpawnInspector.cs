using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AgentSpawn)), CanEditMultipleObjects]
public class AgentSpawnInspector : Editor
{
    public override void OnInspectorGUI()
    {
        AgentSpawn script = (AgentSpawn) target;

        DrawDefaultInspector();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Spawn Agent"))
        {
            script.SpawnAgent_Editor();
        }
        if (GUILayout.Button("Remove Agents"))
        {
            script.RemoveAgents_Editor();
        }
        GUILayout.EndHorizontal();

        //GUILayout.BeginHorizontal();
        //if (GUILayout.Button("Update Adjectives"))
        //{
            
        //}
        //if (GUILayout.Button("Update Nouns"))
        //{
            
        //}
        //GUILayout.EndHorizontal();
    }
}