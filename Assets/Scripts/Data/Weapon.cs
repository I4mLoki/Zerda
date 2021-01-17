using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Custom/Weapon")]
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