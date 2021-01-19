using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Controllers;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class ActionFollowPlayer : MonoBehaviour
{
	[Header("Seek Area")]
	public float damping;
	public float minRange;
 	public float maxRange;
    [SerializeField]
    private bool canRotate;
    [Space(20)]
	[Header("Patrol")]
	public List<GameObject> waypoints;
	public int waypointIndex = 0;
	public GameObject currentWaypoint;
	
	private Animator _animator;
	private Transform _target;
	private Controller _controller;
	private Transform _currentPosition;
	private void Awake()
	{
		_animator = gameObject.GetComponent<Animator>();
		_controller = gameObject.GetComponent<Controller>();
		_target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void Start()
	{
		currentWaypoint = waypoints[waypointIndex];
	}

	private void Update()
	{
		Follow(Seek(_target) ? _target : currentWaypoint.transform);

	}
	private void LateUpdate()
	{
		if(canRotate)
			Rotate();
	}

	private void Follow(Transform target)
	{
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _controller.Character.speed * Time.deltaTime);
		_currentPosition = transform;
	}
	
	private void LookAtPlayer()
	{
		Vector3 targetPostition = new Vector3( _target.position.x, transform.position.y, _target.position.z ) ; 
		// transform.LookAt(targetPostition);
		
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetPostition), damping);
	}

	private void Patrol()
	{
		
	}

	private void Rotate()
	{
		if (Seek(_target))
			LookAtPlayer();
		else
		{
			transform.rotation = _currentPosition.transform.rotation;
		}
	}
	bool Seek(Transform target)
	{
		if (Vector3.Distance(_target.position, transform.position) <= maxRange &&
			Vector3.Distance(_target.position, transform.position) >= minRange)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	

}

