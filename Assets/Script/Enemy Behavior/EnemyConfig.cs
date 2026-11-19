using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyConfig")]

public class EnemyConfig : ScriptableObject{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement")]
    public float patrolSpeed = 3;
    [Header("Patrol")]
    public float groundCheckDistance = 0.7f;
    public LayerMask groundLayer;
    public float wallCheckDistance = .5f;
    public LayerMask wallLayer;
    public float chaseSpeed = 3;

    [Header("Type")]
    public bool isFlying;

    [Header("Flying")]
    public float flySpeed = 3f;
    public float bobAmplitude = 1f;
    public float bobFrequency = 2f;
}
