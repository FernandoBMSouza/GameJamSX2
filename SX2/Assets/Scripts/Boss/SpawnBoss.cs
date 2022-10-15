using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public Transform spawnPointBoss;
    private GameObject bossPrefab;

    private float count;
    private float bossInterval = 15f;
    private bool isOnScene = false;

    private float wave;
    public float waveProgress;

    private void Start()
    {
        bossPrefab = Resources.Load<GameObject>("Prefabs/Boss");
        spawnPointBoss = GameObject.Find("SpawnPointBoss").GetComponent<Transform>();
    }
    
    void Update()
    {
        wave = wave + Time.deltaTime;
        if (wave >= 50f)
        {
            if (isOnScene != true)
            {
                this.count = count + Time.deltaTime;
                if (count >= bossInterval)
                {
                    BossSpawner();
                    isOnScene = true;
                    this.count = 0f;
                    Debug.Log("Boss Spawnou");
                }
            }
        }
        
    }

    void BossSpawner()
    {
        Instantiate(bossPrefab, spawnPointBoss.position, transform.rotation);
    }

    public void WaveManager()
    {
        
    }
}