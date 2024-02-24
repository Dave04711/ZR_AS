using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour
{
    [SerializeField] private bool customSpeed = false;
    [SerializeField] private float customSpeedValue = 5;
    [Space]
    [SerializeField] private float threshold = .015f;

    private AgentsMovement movement;
    private Vector3 target;

    private void Start()
    {
        movement = GameManager.Instance.AgentsMovement;
        SetNewTarget();
    }

    private void Update()
    {
        Move();
    }

    public void SetNewTarget()
    {
        target = movement.RandomPoint;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, (customSpeed ? customSpeedValue : movement.DefaultSpeed) * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) <= threshold)
        {
            SetNewTarget();
        }
    }
}