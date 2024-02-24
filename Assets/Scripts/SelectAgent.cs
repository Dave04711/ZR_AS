using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAgent : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private UIHandler UI;

    private RaycastHit raycastHit;

    private void Awake()
    {
        UI = GetComponent<UIHandler>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                SetAgentData(raycastHit.collider.GetComponent<Health>());
            }
        }
    }

    public void SetAgentData(Health _health)
    {
        if (UI.AgentData != null)
        {
            UI.AgentData.GetComponent<Callbacks>()?.OnRelease?.Invoke();
        }
        if (_health != null)
        {
            _health.GetComponent<Callbacks>()?.OnClick?.Invoke();
        }

        UI.AgentData = _health;
    }
}