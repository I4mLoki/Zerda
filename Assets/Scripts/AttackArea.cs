using System.Collections.Generic;
using Data;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public bool enemyInArea;
    public List<GameObject> enemies;
    private Character _character;

    public Character Character
    {
        set => _character = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_character == null)
            return;

        if (other.CompareTag(_character.target))
        {
            var enemy = other.gameObject;

            enemies.Add(enemy);
            enemyInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_character == null)
            return;
        
        if (other.CompareTag(_character.target))
        {
            var enemy = other.gameObject;

            enemies.Remove(enemy);

            if (enemies.Count == 0)
                enemyInArea = false;
        }
    }
}