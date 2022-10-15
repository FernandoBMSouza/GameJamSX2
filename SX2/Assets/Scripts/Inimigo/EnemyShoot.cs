using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private GameObject bullet;
    private Transform bulletTransform;

    void Start()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletTransform = GameObject.Find("ShootPoint").GetComponent<Transform>();
    }


    void Update()
    {
        
    }
}
