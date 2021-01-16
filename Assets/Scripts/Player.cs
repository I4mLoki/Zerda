using System;
using System.Collections.Generic;
using Controllers;
using Model;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Character character;

    private PlayerController _playerController;
    private Health _health;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _health = GetComponent<Health>();

        _playerController.Character = character;
        _health.Character = character;
    }
}