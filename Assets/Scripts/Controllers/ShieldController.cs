using UnityEngine;

namespace Controllers
{
    public class ShieldController : MonoBehaviour
    {
        private Stamina _stamina;
        private Actions _actions;

        private void Awake()
        {
            _stamina = GetComponent<Stamina>();
            _actions = GetComponent<Actions>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                _stamina.UseContinuousStamina(_actions.ShieldCost);
            }
        }
    }
}