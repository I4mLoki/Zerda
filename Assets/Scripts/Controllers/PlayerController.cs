using System;
using Data;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private float _inputHorizontalSpeed;
        private float _inputVerticalSpeed;
        private Rigidbody _rigidbody;

        private Character _character;
        private WeaponController _weaponController;
        private ShieldController _shieldController;
        private Stamina _stamina;

        public Character Character
        {
            set => _character = value;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _weaponController = GetComponent<WeaponController>();
            _shieldController = GetComponent<ShieldController>();
            _stamina = GetComponent<Stamina>();
        }

        private void Update()
        {
            _inputHorizontalSpeed = Input.GetAxis("Horizontal") * _character.speed;
            _inputVerticalSpeed = Input.GetAxis("Vertical") * _character.speed;

            _rigidbody.velocity = new Vector2(_inputHorizontalSpeed, _inputVerticalSpeed);

            if (Input.GetKeyDown(KeyCode.Mouse0) && _stamina.CanUseStamina)
            {
                _weaponController.Attack(_shieldController.Shielded);
                _shieldController.ShieldDown();
            }

            if (Input.GetKey(KeyCode.Mouse1) && _stamina.CanUseStamina)
                _shieldController.ShieldUp();
            else
                _shieldController.ShieldDown();
        }

        private void LateUpdate()
        {
            ChangeWeapon();
        }

        private void ChangeWeapon()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                _weaponController.SelectNextWeapon();
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                _weaponController.SelectPreviousWeapon();
        }
    }
}