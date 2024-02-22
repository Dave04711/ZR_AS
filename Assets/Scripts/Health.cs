using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int health;
    [SerializeField] private int damage = 1;

    private void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            Die();
        }
        //delegate
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider _other)
    {
        Health health = _other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.DealDamage(damage);
        }
    }
}