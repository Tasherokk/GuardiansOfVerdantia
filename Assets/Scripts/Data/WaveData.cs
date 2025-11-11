using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewWaveData", menuName = "Tower Defense/Wave Data")]
public class WaveData : ScriptableObject
{
    public string waveName = "New Wave";
    public List<EnemyData> enemiesInWave = new List<EnemyData>();
    public int enemyCount = 10;
    public float spawnInterval = 1f;

    // Validation (optional, can be done in editor script or runtime)
    void OnValidate()
    {
        if (enemyCount <= 0) enemyCount = 1;
        if (spawnInterval <= 0) spawnInterval = 0.1f;
        if (enemiesInWave == null || enemiesInWave.Count == 0)
        {
            Debug.LogWarning("WaveData: enemiesInWave list is empty. Please assign EnemyData assets.", this);
        }
    }
}
