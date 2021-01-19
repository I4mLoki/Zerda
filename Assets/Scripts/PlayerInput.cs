using System;
using Controllers;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _movement;
    private Controller _playerController;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _playerController = GetComponent<Controller>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.z = Input.GetAxisRaw("Vertical");
        // _movement.x = (float)Math.Round(Input.GetAxisRaw("Horizontal")); 
        // _movement.z = (float)Math.Round(Input.GetAxisRaw("Vertical"));
        _playerController.Move(_movement);
    }
}
