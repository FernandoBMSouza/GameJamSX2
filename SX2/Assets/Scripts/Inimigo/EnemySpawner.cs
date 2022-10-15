using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnRate;
    private float nextSpawn;

    [SerializeField] private int max;
    private int cont;

    private void Update()
    {
        if(cont < max)
        {
            InstantiateEnemy();
        }
    }

    private void InstantiateEnemy()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            RandomizeEnemy();
            Instantiate(enemy, transform.position, enemy.transform.rotation);
            cont++;
        }
    }

    private void RandomizeEnemy()
    {
        int random = Random.Range(0, 2);

        switch (random)
        {
            case 0:
                enemy = Resources.Load<GameObject>("Prefabs/DPSEnemy");
                break;
            case 1:
                enemy = Resources.Load<GameObject>("Prefabs/TankerEnemy");
                break;
        }
    }
}
