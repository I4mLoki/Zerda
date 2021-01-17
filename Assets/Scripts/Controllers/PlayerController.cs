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

        public Character Character
        {
            set => _character = value;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _inputHorizontalSpeed = Input.GetAxis("Horizontal") * _character.speed;
            _inputVerticalSpeed = Input.GetAxis("Vertical") * _character.speed;

            _rigidbody.velocity = new Vector2(_inputHorizontalSpeed, _inputVerticalSpeed);
        }
    }
}