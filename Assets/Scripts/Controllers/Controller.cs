using System;
using Model;
using UnityEngine;
namespace Controllers
{
	public class Controller : MonoBehaviour
	{
		public bool canRotate;
		public Animator animator;
		public Character Character
		{
			get => _character;
			set => _character = value;
		}

		Vector3 _movement;
		Vector3 _pushDirection;
		private Vector3 _impact;
		private Rigidbody _rb;
		
		private Character _character;
		private float PushPower = 2f;
		private Quaternion _newQuaternion;
		private Rigidbody _pushedRigidbody;
		private void Awake()
        { 
	        _rb = GetComponent<Rigidbody>();
        }
		private void Update()
		{
			if(canRotate)
				Rotate(_movement);
		}

		private void FixedUpdate()
		{
			_rb.MovePosition(_rb.position + _movement * (_character.speed * Time.fixedDeltaTime));
		}
	
		public void Move(Vector3 _move)
		{
			_movement.x = _move.x;
			_movement.z = _move.z;
			
			animator.SetFloat("Horizontal", _movement.x);
			animator.SetFloat("Vertical", _movement.z);
			animator.SetFloat("Speed", _movement.sqrMagnitude);
		}

		public void Rotate(Vector3 _move)
		{
			var angle = Mathf.Atan2(_move.x, _move.z) * Mathf.Rad2Deg;

			if (_move != Vector3.zero)
			{
				_newQuaternion = Quaternion.Euler(Vector3.up * (angle));
			}

			transform.rotation = _newQuaternion;
		}
	
		protected virtual void HandlePush(ControllerColliderHit hit, Vector3 hitPosition)
		{

			_pushedRigidbody = hit.collider.attachedRigidbody;

			if ((_pushedRigidbody == null) || (_pushedRigidbody.isKinematic))
			{
				return;
			}
            
			_pushDirection.x = hit.moveDirection.x;
			_pushDirection.y = 0;
			_pushDirection.z = hit.moveDirection.z;

			_pushedRigidbody.AddForceAtPosition(_pushDirection * PushPower, hitPosition);
		}
		protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
		{
			HandlePush(hit, hit.point);
		}
	}
}

