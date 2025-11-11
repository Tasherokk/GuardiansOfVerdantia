using UnityEngine;

public class FlamesTower : Tower
{
    public float aoeRadius = 1.5f; // Radius for AoE damage

    protected override void Attack()
    {
        if (currentTarget != null)
        {
            Debug.Log($"{towerData.towerName} (Flames) attacking {currentTarget.name} for {towerData.damage} AoE damage.");
            
            // Find all enemies within AoE radius
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(currentTarget.transform.position, aoeRadius);
            foreach (Collider2D hitCollider in hitColliders)
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(towerData.damage);
                }
            }
        }
    }

    // Optional: Draw AoE radius in editor for visualization
    private void OnDrawGizmosSelected()
    {
        if (currentTarget != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(currentTarget.transform.position, aoeRadius);
        }
    }
}
