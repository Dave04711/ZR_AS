using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

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

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Update Adjectives"))
        {
            script.adjectives = GetLines("Text/Adjectives");
        }
        if (GUILayout.Button("Update Nouns"))
        {
            script.nouns = GetLines("Text/Nouns");
        }
        GUILayout.EndHorizontal();
    }

    private string[] GetLines(string _path)
    {
        var textFile = Resources.Load<TextAsset>(_path);
        return textFile.text.Split("\n"[0]);
    }
}