using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAction : MonoBehaviour
{
	[SerializeField] private float dashForce = 10f;
	private Rigidbody _rb;
	private Animator _animator;
	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_animator = GetComponent<Animator>();
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			Dash();
	}
	private void Dash()
	{
		_animator.Play("Dashing");
		_rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
	}
}
