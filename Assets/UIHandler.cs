using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject agentDetailsObject;
    private Health agentData;
    private VisualElement root;
    private ProgressBar progressBar;

    private void Awake()
    {
        root = agentDetailsObject.GetComponent<UIDocument>().rootVisualElement;
        progressBar = root.Q<ProgressBar>("AgentData");
    }

    private void Update()
    {
        bool isAgentSelected = agentData != null;
        progressBar.style.display = isAgentSelected ? DisplayStyle.Flex : DisplayStyle.None;
        if (isAgentSelected)
        {
            progressBar.title = agentData.name;
            progressBar.value = agentData.CurrentHealth;
            progressBar.highValue = agentData.MaxHealth;
        }
    }

    public void ShowAgentUI(Health _health)
    {
        agentData = _health;
    }
}