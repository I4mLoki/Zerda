using UnityEngine;

namespace Controllers
{
    public class ShieldController : MonoBehaviour
    {
        private Stamina _stamina;
        private Actions _actions;
        private bool _shielded;

        public bool Shielded => _shielded;

        private void Awake()
        {
            _stamina = GetComponent<Stamina>();
            _actions = GetComponent<Actions>();
        }

        public void ShieldUp()
        {
            _stamina.UseContinuousStamina(_actions.ShieldMaintenanceCost);
            _shielded = true;
        }
        
        public void ShieldDown()
        {
            _shielded = false;
        }
    }
}