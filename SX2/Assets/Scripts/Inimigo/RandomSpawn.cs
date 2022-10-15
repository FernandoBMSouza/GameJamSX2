using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn(); 
    }

    public void Spawn()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoints = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefabs[0], spawnPoints[0].position, transform.rotation);
     
    } 
}
