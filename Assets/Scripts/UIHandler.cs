using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject agentDetailsObject;
    [HideInInspector] public Health AgentData;
    private VisualElement root;
    private ProgressBar progressBar;
    private Button generateButton;
    private Label randomValueLabelFirst, randomValueLabelLast;
    private List<Label> randomValueLabels = new List<Label>();
    private VisualElement randomValueParent;
    private string randomValue;
    private readonly WaitForSeconds animationDuration = new WaitForSeconds(1);

    private void Awake()
    {
        root = agentDetailsObject.GetComponent<UIDocument>().rootVisualElement;
        progressBar = root.Q<ProgressBar>("AgentData");
        generateButton = root.Q<Button>("Generate-Values-Button");
        randomValueLabelFirst = root.Q<Label>("First-Label");
        randomValueLabelLast = root.Q<Label>("Last-Label");
        randomValueLabels = root.Query<Label>(className: "Random-Values-Label").ToList();
        randomValueParent = root.Q<VisualElement>("Random-Labels-Parent");
    }

    private void Start()
    {
        generateButton.clicked += UpdateText;
    }

    private void Update()
    {
        bool isAgentSelected = AgentData != null;
        if (isAgentSelected && !AgentData.gameObject.activeInHierarchy)
        {
            AgentData = null;
            return;
        }
        progressBar.style.display = isAgentSelected ? DisplayStyle.Flex : DisplayStyle.None;
        if (isAgentSelected)
        {
            progressBar.title = AgentData.name;
            progressBar.value = AgentData.CurrentHealth;
            progressBar.highValue = AgentData.MaxHealth;
        }
    }

    private void UpdateText()
    {
        StartCoroutine(Generate());

        IEnumerator Generate()
        {
            generateButton.pickingMode = PickingMode.Ignore;
            randomValue = ValueGenerate();
            randomValueLabelFirst.text = randomValue;
            for (int i = 0; i < randomValueLabels.Count; i++)
            {
                randomValueLabels[i].text = ValueGenerate();
            }
            randomValueParent.AddToClassList("Random-Labels-Parent-Anim");
            yield return animationDuration;
            randomValueLabelLast.text = randomValue;
            randomValueParent.RemoveFromClassList("Random-Labels-Parent-Anim");
            generateButton.pickingMode = PickingMode.Position;
        }

        string ValueGenerate()
        {
            int randomValue = Random.Range(1, 101);

            bool canDivideBy3 = randomValue % 3 == 0;
            bool canDivideBy5 = randomValue % 5 == 0;

            if (canDivideBy3 && canDivideBy5)
            {
                return "MarkoPolo";
            }
            else if (canDivideBy3)
            {
                return "Marko";
            }
            else if (canDivideBy5)
            {
                return "Polo";
            }
            else
            {
                return randomValue.ToString();
            }
        }
    }
}