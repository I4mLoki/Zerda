using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private List<Weapon> weapons;

        private Health _health;
        private Weapon _currentWeapon;
        private int _currentWeaponIndex;
        private AttackArea _attackArea;
        private Stamina _stamina;
        private Actions _actions;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _attackArea = GetComponentInChildren<AttackArea>();
            _stamina = GetComponent<Stamina>();
            _actions = GetComponent<Actions>();

            Setup();
            ChangeWeapon();
        }

        public void Attack(bool enemyShielded)
        {
            if (_currentWeapon == null)
                return;
            
            if (_attackArea.enemies.Count > 0 && !enemyShielded)
                _health.DealDamage(_currentWeapon.damage, _attackArea.enemies);
            else if (enemyShielded)
                _health.DealDamage(_currentWeapon.damage, _attackArea.enemies);

            if (gameObject.CompareTag("Player"))
                _stamina.UseStamina(_actions.AttackCost);
        }

        private void Setup()
        {
            const int index = 0;
            _currentWeapon = weapons[index];
            _currentWeaponIndex = index;
        }

        public void SelectNextWeapon()
        {
            _currentWeaponIndex++;

            if (weapons.Count <= _currentWeaponIndex)
                _currentWeaponIndex = 0;

            _currentWeapon = weapons[_currentWeaponIndex];
            ChangeWeapon();
        }

        public void SelectPreviousWeapon()
        {
            _currentWeaponIndex--;

            if (_currentWeaponIndex < 0)
                _currentWeaponIndex = weapons.Count - 1;

            _currentWeapon = weapons[_currentWeaponIndex];
            ChangeWeapon();
        }

        private void ChangeWeapon()
        {
            if (_attackArea.TryGetComponent<BoxCollider>(out var attackCollider))
            {
                if (_currentWeapon == null)
                    return;
                
                attackCollider.size = new Vector3(attackCollider.size.x, _currentWeapon.range);
                attackCollider.center = new Vector3(attackCollider.center.x, _currentWeapon.Center);
                // Debug.Log($"New weapon selected is {_currentWeapon.name}");
            }
        }
    }
}