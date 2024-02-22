using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int health;
    public int CurrentHealth => health;
    public int MaxHealth => maxHealth;

    private Callbacks callbacks;

    private void Awake()
    {
        callbacks = GetComponent<Callbacks>();
    }

    private void Start()
    {
        health = maxHealth;

        callbacks.OnClick += SetUI;
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

    private void SetUI()
    {
        GameManager.Instance.UI.ShowAgentUI(this);
    }
}