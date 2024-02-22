using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentsMovement : MonoBehaviour
{
    [Range(0, 20)]
    public float DefaultSpeed = 1.0f;
    public Vector2 MapSize = Vector2.one;
}