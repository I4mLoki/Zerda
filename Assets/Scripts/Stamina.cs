using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private Character _character;
    private bool _canUseStamina;
    private float _stamina;
    public bool CanUseStamina => _canUseStamina;

    public Character Character
    {
        set => _character = value;
    }


    private void Start()
    {
        _canUseStamina = true;
        slider.maxValue = _character.stamina;
        ResetStamina();
    }

    private void Update()
    {
        RecoveryStamina();
    }

    public void UseStamina(float amount)
    {
        if (_stamina > 0)
            _stamina -= amount;
        else
            _canUseStamina = false;

        slider.value = _stamina;
    }

    public void UseContinuousStamina(float amount)
    {
        var speed = amount * Time.deltaTime;

        if (_stamina > 0)
            _stamina -= speed;
        else
            _canUseStamina = false;

        slider.value = _stamina;
    }

    private void RecoveryStamina()
    {
        var speed = _character.staminaRecoverySpeed * Time.deltaTime;

        if (_stamina < _character.stamina)
        {
            _stamina += speed;
            if (_stamina > _character.stamina)
                _stamina = _character.stamina;
        }
        else
            _canUseStamina = true;

        slider.value = _stamina;
    }

    private void ResetStamina()
    {
        _stamina = _character.stamina;
        slider.value = _stamina;
    }
}