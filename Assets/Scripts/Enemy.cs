using System;
using System.Collections;
using Controllers;
using Data;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Character character;

    private Health _health;
    private AttackArea _attackArea;
    private WeaponController _weaponController;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _attackArea = GetComponentInChildren<AttackArea>();
        _weaponController = GetComponent<WeaponController>();

        _health.Character = character;
        _attackArea.Character = character;
    }

    private void Start()
    {
        InvokeRepeating("Attack", 0.0f, 3f);
    }

    private void Attack()
    {
        _weaponController.Attack(false);
    }
}