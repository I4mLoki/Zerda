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

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _health = GetComponent<Health>();
        _stamina = GetComponent<Stamina>();

        _playerController.Character = character;
        _health.Character = character;
        _stamina.Character = character;
    }
}