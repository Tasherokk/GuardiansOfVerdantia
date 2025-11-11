using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Tower Defense/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName = "New Enemy";
    public GameObject enemyPrefab;
    public float health = 70f;
    public float speed = 2f;
    public int manaOnKill = 5;

    // Validation (optional, can be done in editor script or runtime)
    void OnValidate()
    {
        if (health <= 0) health = 0.1f;
        if (speed <= 0) speed = 0.1f;
        if (manaOnKill < 0) manaOnKill = 0;
    }
}
