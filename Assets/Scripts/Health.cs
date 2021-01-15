using System;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class Health : MonoBehaviour
{

    private Character _character;

    public Character Character
    {
        set => _character = value;
    }

    private int _health;

    private void Start()
    {
        ResetHealth();
    }

    public void DealDamage(int damage, List<GameObject> enemies)
    {
        foreach (var enemy in enemies)
        {
            if (enemy.TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private void ResetHealth()
    {
        _health = _character.health;
    }
}