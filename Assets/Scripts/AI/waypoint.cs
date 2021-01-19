using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
	private ActionFollowPlayer _enemy;
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			_enemy = other.gameObject.GetComponent<ActionFollowPlayer>();
			if (_enemy.waypointIndex < _enemy.waypoints.Count - 1)
				_enemy.waypointIndex++;
			else
				_enemy.waypointIndex = 0;
			
			_enemy.currentWaypoint = _enemy.waypoints[_enemy.waypointIndex];
		}
	}
}
