using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] private float attackCost;
    [SerializeField] private float shieldMaintenanceCost;
    [SerializeField] private float shieldImpactCost;
    [SerializeField] private float dashCost;

    public float AttackCost => attackCost;
    public float ShieldMaintenanceCost => shieldMaintenanceCost;
    public float ShieldImpactCost => shieldImpactCost;
    public float DashCost => dashCost;
}