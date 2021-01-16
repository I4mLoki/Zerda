using System;
using Model;
using UnityEngine;
namespace Controllers
{
	public class PlayerController : MonoBehaviour
	{
		public Rigidbody rb;
		public Animator animator;
		private Character _character;

		public Character Character
		{
			set => _character = value;
		}
	
		Vector3 _movement;
		private Vector3 _impact;
		public float _lookDir;
		public Quaternion _newQuaternion;
		private void Update()
		{
			Move();
			Rotate();
		}


		private void FixedUpdate()
		{
			ApplyImpact();
		
			rb.MovePosition(rb.position + _movement * (_character.speed * Time.fixedDeltaTime));
			//transform.rotation = _lookDir;
		}
	
		private void Move()
		{
		
			_movement.x = (float)Math.Round(Input.GetAxis("Horizontal")); 
			_movement.y = (float)Math.Round(Input.GetAxis("Vertical")); 
        
			animator.SetFloat("Horizontal", _movement.x);
			animator.SetFloat("Vertical", _movement.y);
			animator.SetFloat("Speed", _movement.sqrMagnitude);
		}
	
		private void Rotate()
		{
			var angle = Mathf.Atan2(-_movement.x, _movement.y) * Mathf.Rad2Deg;

			if (_movement != Vector3.zero)
			{
				_newQuaternion = Quaternion.Euler(Vector3.forward * (angle));
			}

			transform.rotation = _newQuaternion;
		}
	
		public void ApplyImpact()
		{
			if (_impact.magnitude > 0.2f)
			{
				rb.AddForce(_impact);
			}
			_impact = Vector3.Lerp(_impact, Vector3.zero, 5f * Time.deltaTime);
        
		}
		public void Impact(Vector3 direction, float force)
		{
			direction = direction.normalized;
			_impact += direction.normalized * force;
		}
	}
}

