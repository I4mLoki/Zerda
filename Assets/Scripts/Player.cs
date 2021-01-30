using System;
using System.Collections.Generic;
using Controllers;
using Data;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Character character;

    private PlayerController _playerController;
    private Health _health;
    private Stamina _stamina;
    private AttackArea _attackArea;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _health = GetComponent<Health>();
        _stamina = GetComponent<Stamina>();
        _attackArea = GetComponentInChildren<AttackArea>();

        _playerController.Character = character;
        _health.Character = character;
        _stamina.Character = character;
        _attackArea.Character = character;
    }
}