using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentsMovement : MonoBehaviour
{
    [Range(0, 20)]
    public float DefaultSpeed = 1.0f;
    [SerializeField] private Vector2 mapSize = Vector2.one;

    public Vector3 RandomPoint => new Vector3(Random.Range(-mapSize.x, mapSize.x), 0, Random.Range(-mapSize.y, mapSize.y));
}