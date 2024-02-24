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
    [Header("Names")]
    [SerializeField] private string[] adjectives;
    [SerializeField] private string[] nouns;

    private AgentsMovement movement;
    private WaitForSeconds interval;

    private IEnumerator Start()
    {
        movement = GameManager.Instance.AgentsMovement;
        spawnCount = Random.Range(spawnMin, spawnMax + 1);
        SetInterval();

        for (int i = 0; i < spawnCount; i++)
        {
            SpawnAgent();
        }

        while (true)
        {
            yield return interval;
            SpawnAgent();
            SetInterval();
        }
    }

    public void SpawnAgent()
    {
        if (!CanSpawn()) { return; }

        GameObject newAgent = NewAgent();

        if (newAgent == null)
        {
            newAgent = Instantiate(agentPrefab, parent);
            agents.Add(newAgent);
        }

        newAgent.SetActive(true);
        newAgent.transform.position = movement.RandomPoint;
        

        if(adjectives.Length == 0 || nouns.Length == 0 )
        {
            newAgent.name = "Bob";
            return;
        }
        newAgent.name = $"{adjectives[Random.Range(0, adjectives.Length)]}{nouns[Random.Range(0, nouns.Length)]}";

        bool CanSpawn()
        {
            int c = 0;
            for (int i = 0; i < agents.Count; i++)
            {
                if (agents[i].activeInHierarchy) { c++; }
            }
            return c < maxAmount;
        }

        GameObject NewAgent()
        {
            for (int i = 0; i < agents.Count; i++)
            {
                if (!agents[i].activeInHierarchy) { return agents[i]; }
            }
            return null;
        }
    }

    private void SetInterval() => interval = new WaitForSeconds(Random.Range(waitTimeMin, waitTimeMax));

#if UNITY_EDITOR

    public void SpawnAgent_Editor()
    {
        movement = FindObjectOfType<AgentsMovement>();
        SpawnAgent();
    }

    public void RemoveAgents_Editor()
    {
        for (int i = parent.childCount; i > 0; --i)
        {
            DestroyImmediate(parent.GetChild(0).gameObject);
        }
        agents.Clear();
    }

#endif
}