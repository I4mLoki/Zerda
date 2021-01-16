using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Character")]
    public class Character : ScriptableObject
    {
        public int health;
        public float speed;
        public string target = "Player";
    }
}