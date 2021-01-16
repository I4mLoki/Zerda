using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private List<Weapon> weapons;

        private Health _health;
        private Weapon _currentWeapon;
        private int _currentWeaponIndex;
        private AttackArea _attackArea;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _attackArea = GetComponentInChildren<AttackArea>();

            Setup();
            ChangeWeapon();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _attackArea.enemyInArea)
                _health.DealDamage(_currentWeapon.damage, _attackArea.enemies);
        }

        private void LateUpdate()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                SelectNextWeapon();
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                SelectPreviousWeapon();
        }

        private void Setup()
        {
            const int index = 0;
            _currentWeapon = weapons[index];
            _currentWeaponIndex = index;
        }
    
        private void SelectNextWeapon()
        {
            _currentWeaponIndex++;

            if (weapons.Count <= _currentWeaponIndex)
                _currentWeaponIndex = 0;

            _currentWeapon = weapons[_currentWeaponIndex];
            ChangeWeapon();
        }

        private void SelectPreviousWeapon()
        {
            _currentWeaponIndex--;

            if (_currentWeaponIndex < 0)
                _currentWeaponIndex = weapons.Count - 1;

            _currentWeapon = weapons[_currentWeaponIndex];
            ChangeWeapon();
        }

        private void ChangeWeapon()
        {
            var attackCollider = _attackArea.GetComponent<BoxCollider>();
            attackCollider.size = new Vector3(attackCollider.size.x, _currentWeapon.range);
            attackCollider.center = new Vector3(attackCollider.center.x, _currentWeapon.Center);
            Debug.Log($"New weapon selected is {_currentWeapon.name}");
        }
    }
}