using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Data;
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
        var enemyTarget = enemies[0];
        var currentDistance = 0f;

        foreach (var enemy in enemies)
        {
            var enemyDistance = Vector2.Distance(transform.position, enemy.transform.position);

            if (enemyDistance < currentDistance || currentDistance == 0f)
            {
                currentDistance = enemyDistance;
                enemyTarget = enemy;
            }
        }

        if (enemyTarget.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(damage);
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