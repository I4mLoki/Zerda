using System;
using Model;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Character character;
    
    private Health _health;
    private AttackArea _attackArea;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _attackArea = GetComponentInChildren<AttackArea>();
        
        _health.Character = character;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _attackArea.enemyInArea)
            _health.DealDamage(character.attack, _attackArea.enemies);
    }
}