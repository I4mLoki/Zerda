using System.Collections.Generic;
using Model;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public bool enemyInArea;
    public List<GameObject> enemies;
    public Character character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(character.target))
        {
            var enemy = other.gameObject;

            enemies.Add(enemy);
            enemyInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(character.target))
        {
            var enemy = other.gameObject;

            enemies.Remove(enemy);

            if (enemies.Count == 0)
                enemyInArea = false;
        }
    }
}