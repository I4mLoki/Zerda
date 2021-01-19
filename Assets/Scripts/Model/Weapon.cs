using System;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Game/Weapon")]
    public class Weapon
        : ScriptableObject
    {
        public int damage;
        public float range;

        [NonSerialized] public float Center;

        private void OnValidate()
        {
            Center = (range + 1) / 2;
        }
    }
}