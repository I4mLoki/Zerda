using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Custom/Character")]
    public class Character : ScriptableObject
    {
        public int health;
        public int stamina;
        public int staminaRecoverySpeed;
        public float speed;
        public string target = "Player";
    }
}