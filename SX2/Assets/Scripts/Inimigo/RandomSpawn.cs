using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    [HideInInspector]
    public float count;
    private float interval = 7f;

    private int wave;
    private float waveProgress;
    
    [HideInInspector]
    public int numSpawn;

    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        this.count = count + Time.deltaTime;
        if(numSpawn != 2)
        {
            if (count >= interval)
            {
                Spawn();
                this.count = 0f;
                this.numSpawn++;
                Debug.Log(numSpawn);
            }
        }
    }

    public void Spawn()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoints = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoints].position, transform.rotation);

    } 

    public void WavesManager()
    {
        

    }


}
