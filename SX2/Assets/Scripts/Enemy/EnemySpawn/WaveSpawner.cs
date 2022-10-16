using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemies;
        public int count;
        public float rate;
    }

    [SerializeField] private TMP_Text currentWaveText;
    [SerializeField] private Wave[] waves;
    private int nextWave = 0;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private void Awake()
    {
        currentWaveText = GameObject.Find("CurrentWaveText").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;    
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            //nextWave = 0;
            //Debug.Log("All Waves Completed! Looping...");
            SceneManager.LoadScene("Vitoria");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawning Wave: " + _wave.name);
        currentWaveText.text = $"{_wave.name}";


        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawEnemy(_wave.enemies);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawEnemy(Transform[] _enemies)
    {
        //Debug.Log("Spawning Enemmy: " + _enemy.name);

        if(spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        int random = Random.Range(0, _enemies.Length);

        Instantiate(_enemies[random], _sp.position, _sp.rotation);
    }
}
