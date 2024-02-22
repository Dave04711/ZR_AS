using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider _other)
    {
        Health health = _other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.DealDamage(damage);
        }
    }
}