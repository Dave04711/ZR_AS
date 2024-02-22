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
    private Button generateButton;
    private Label valueText;

    private void Awake()
    {
        root = agentDetailsObject.GetComponent<UIDocument>().rootVisualElement;
        progressBar = root.Q<ProgressBar>("AgentData");
        generateButton = root.Q<Button>("GenerateValueButton");
        valueText = root.Q<Label>("GenerateValueText");
    }

    private void Start()
    {
        generateButton.clicked += UpdateText;
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

    private void UpdateText()
    {
        StartCoroutine(Generate());

        IEnumerator Generate()
        {
            for (int i = 1; i <= 15; i++)
            {
                ValueGenerate();
                yield return new WaitForSeconds((float) i / 30f);
            }
        }
    }

    private void ValueGenerate()
    {
        int randomValue = Random.Range(1, 101);

        bool canDivideBy3 = randomValue % 3 == 0;
        bool canDivideBy5 = randomValue % 5 == 0;

        if (canDivideBy3 && canDivideBy5)
        {
            valueText.text = "MarkoPolo";
        }
        else if(canDivideBy3)
        {
            valueText.text = "Marko";
        }
        else if (canDivideBy5)
        {
            valueText.text = "Polo";
        }
        else
        {
            valueText.text = randomValue.ToString();
        }
    }
}