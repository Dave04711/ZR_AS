using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private bool customSpeed = false;

    private void Update()
    {
        Move();
    }

    public void SetNewTarget()
    {

    }

    private void Move()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}