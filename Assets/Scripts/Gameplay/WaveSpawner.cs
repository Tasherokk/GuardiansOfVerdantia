using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner Instance { get; private set; } // Singleton

    public List<WaveData> waves;
    public Transform spawnPoint;
    public List<Transform> enemyWaypoints; // Assign in Inspector

    private int _currentWaveIndex = 0;
    private bool _isSpawning = false;
    private int _enemiesAlive = 0; // Track enemies alive

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnWaveChanged += HandleWaveChanged;
        }
        StartNextWave();
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnWaveChanged -= HandleWaveChanged;
        }
    }

    private void HandleWaveChanged(int waveNumber)
    {
        // Logic to react to wave changes, e.g., update UI, prepare next wave
    }

    public void EnemyDied()
    {
        _enemiesAlive--;
        if (!_isSpawning && _enemiesAlive <= 0)
        {
            // All enemies from current wave defeated
            // Start next wave after a short delay
            StartCoroutine(NextWaveAfterDelay(3f));
        }
    }

    private IEnumerator NextWaveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _currentWaveIndex++;
        StartNextWave();
    }

    public void StartNextWave()
    {
        if (_currentWaveIndex < waves.Count)
        {
            GameManager.Instance.CurrentWave = _currentWaveIndex + 1; // Update GameManager
            StartCoroutine(SpawnWave(waves[_currentWaveIndex]));
        }
        else
        {
            // All waves completed
            Debug.Log("All waves completed!");
            if (GameManager.Instance != null)
            {
                GameManager.Instance.HandleGameWin(); // Call game win
            }
        }
    }

    private IEnumerator SpawnWave(WaveData wave)
    {
        _isSpawning = true;
        Debug.Log($"Starting Wave: {wave.waveName}");
        _enemiesAlive = wave.enemyCount; // Reset enemies alive for new wave

        for (int i = 0; i < wave.enemyCount; i++)
        {
            if (wave.enemiesInWave.Count > 0)
            {
                EnemyData enemyToSpawnData = wave.enemiesInWave[Random.Range(0, wave.enemiesInWave.Count)];
                GameObject enemyGO = Instantiate(enemyToSpawnData.enemyPrefab, spawnPoint.position, Quaternion.identity);
                Enemy enemy = enemyGO.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.enemyData = enemyToSpawnData; // Assign data to enemy instance
                    EnemyMovement enemyMovement = enemyGO.GetComponent<EnemyMovement>();
                    if (enemyMovement != null)
                    {
                        enemyMovement.waypoints = enemyWaypoints;
                    }
                }
            }
            yield return new WaitForSeconds(wave.spawnInterval);
        }

        _isSpawning = false;
        // Check if all enemies are defeated after spawning is complete
        if (_enemiesAlive <= 0)
        {
            StartCoroutine(NextWaveAfterDelay(3f));
        }
    }
}