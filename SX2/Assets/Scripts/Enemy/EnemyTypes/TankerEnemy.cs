using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerEnemy : Enemy
{
    [SerializeField] private float fireRate;

    public TankerEnemy()
    {
        health = 5f;
        moveSpeed = 2f;
    }

    protected override void Awake()
    {
        base.Awake();
        weapon = GetComponentInChildren<EnemyWeapon>();
    }

    private void Start()
    {
        SetFireRate();
    }

    private void SetFireRate()
    {
        weapon.FireRate = fireRate;
    }
}
