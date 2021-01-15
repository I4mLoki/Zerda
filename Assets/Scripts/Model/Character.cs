using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Character")]
    public class Character : ScriptableObject
    {
        public int health;
        public int attack;
        public float speed;
        public string target = "Player";

        public void Print()
        {
            Debug.Log(name);
        }
    }
}