using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;

    //Bullet
    private GameObject bullet;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private bool canFire;
    private float timer;
    [SerializeField] private float timeBetweenFiring;

    private void Awake()
    {
        mainCamera = Camera.main;
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletTransform = GameObject.Find("BulletTranform").GetComponent<Transform>();
        canFire = true;
    }

    private void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            WeaponRotation(mousePosition);
            Fire();
        }
    }

    private void WeaponRotation(Vector3 mousePosition)
    {
        Vector3 rotation = mousePosition - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    private void Fire()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
        else if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
