using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    private float _currentHealth;

    private void Awake()
    {
        if (enemyData == null)
        {
            Debug.LogError("EnemyData is not assigned to " + gameObject.name, this);
            enabled = false; // Disable script if no data
            return;
        }
        _currentHealth = enemyData.health;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddMana(enemyData.manaOnKill);
        }
        if (WaveSpawner.Instance != null) // Call EnemyDied on WaveSpawner
        {
            WaveSpawner.Instance.EnemyDied();
        }
        Destroy(gameObject);
    }

    // Placeholder for movement logic (will be handled by EnemyMovement.cs)
    public void MoveTo(Vector3 targetPosition)
    {
        // This will be implemented in EnemyMovement.cs
    }

    // Placeholder for reaching core logic (will be handled by EnemyMovement.cs)
    public void ReachCore()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TakeCoreDamage(1); // Each enemy reaching core deals 1 damage
        }
        if (WaveSpawner.Instance != null) // Call EnemyDied on WaveSpawner
        {
            WaveSpawner.Instance.EnemyDied(); // Enemy reaching core also counts as "dying" for wave tracking
        }
        Destroy(gameObject);
    }
}