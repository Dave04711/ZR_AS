using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int health;

    private Callbacks callbacks;

    private void Awake()
    {
        callbacks = GetComponent<Callbacks>();
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(int _damage)
    {
        callbacks?.OnHit?.Invoke();

        health -= _damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}