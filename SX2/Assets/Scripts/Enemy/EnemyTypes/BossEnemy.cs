using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : Enemy
{
    [SerializeField] private float fireRate;

    public BossEnemy()
    {
        health = 10f;
        moveSpeed = 4f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tree")
        {
            SceneManager.LoadScene("Derrota");
        }
    }
}
