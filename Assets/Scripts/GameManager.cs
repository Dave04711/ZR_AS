using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AgentsMovement AgentsMovement;
    public UIHandler UI;

    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        AgentsMovement = GetComponent<AgentsMovement>();
        UI = GetComponent<UIHandler>();
    }

    #endregion
}