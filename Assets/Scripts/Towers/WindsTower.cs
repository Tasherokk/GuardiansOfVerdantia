using UnityEngine;

public class WindsTower : Tower
{
    public float knockbackForce = 2f; // Force of the knockback

    protected override void Attack()
    {
        if (currentTarget != null)
        {
            Debug.Log($"{towerData.towerName} (Winds) attacking {currentTarget.name} for {towerData.damage} damage and knocking back.");
            currentTarget.TakeDamage(towerData.damage);
            
            // Implement knockback effect
            // For MVP, we can directly manipulate the enemy's position or apply a force
            // This assumes EnemyMovement has a method to handle external forces or position changes
            EnemyMovement enemyMovement = currentTarget.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                // Simple knockback: move enemy back along its path
                // This would require more sophisticated path management in EnemyMovement
                // For now, a simple position change or force application
                currentTarget.transform.position -= currentTarget.transform.forward * knockbackForce; // Example: move back along its forward vector
            }
        }
    }
}
