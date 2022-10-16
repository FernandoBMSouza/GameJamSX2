using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float fireRate;
    float nextFire;


    private void Awake()
    {
        bullet = Resources.Load<GameObject>("Prefabs/EnemyBullet");
    }

    private void Start()
    {
        nextFire = Time.deltaTime;
    }

    private void Update()
    {
        CheckTimeToFire();
    }

    private void CheckTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
