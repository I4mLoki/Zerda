using Data;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Character character;
    
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        
        _health.Character = character;
    }
}