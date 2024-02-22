using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawn : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private int spawnMin = 3;
    [SerializeField] private int spawnMax = 5;
    private int spawnCount = 0;
    [Space]
    [SerializeField] private float waitTimeMin = 2;
    [SerializeField] private float waitTimeMax = 6;
    [Space]
    [SerializeField] private Transform parent;
    private List<GameObject> agents = new List<GameObject>();
    [SerializeField] private GameObject agentPrefab;
    [SerializeField] private int maxAmount = 30;
    [Header("Grid")]
    [SerializeField] private Vector2 size = Vector2.one;
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 1;
    [Header("Names")]
    [SerializeField] private string[] adjectives;
    [SerializeField] private string[] nouns;

    public void SpawnAgent()
    {
        var newAgent = Instantiate(agentPrefab, parent);
        newAgent.transform.position = new Vector3(Random.Range(-size.x, size.x), 0, Random.Range(-size.y, size.y));
        if(adjectives.Length == 0 || nouns.Length == 0 )
        {
            newAgent.name = "Bob";
            return;
        }
        newAgent.name = $"{adjectives[Random.Range(0, adjectives.Length)]}{nouns[Random.Range(0, nouns.Length)]}";
    }
}