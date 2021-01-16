using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            Debug.Log($"{gameObject.name} has dealt {damage} damage to {enemyTarget.name}");
            health.TakeDamage(damage);
        }
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"{gameObject.name}'s current health is now {_health}");
    }

    private void ResetHealth()
    {
        _health = _character.health;
    }
}