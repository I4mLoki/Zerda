using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] private float attackCost;
    [SerializeField] private float shieldCost;
    [SerializeField] private float dashCost;

    public float AttackCost => attackCost;
    public float ShieldCost => shieldCost;
    public float DashCost => dashCost;
}