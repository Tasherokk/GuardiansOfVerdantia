using UnityEngine;

public class ThornsTower : Tower
{
    protected override void Attack()
    {
        if (currentTarget != null)
        {
            Debug.Log($"{towerData.towerName} (Thorns) attacking {currentTarget.name} for {towerData.damage} damage and slowing.");
            currentTarget.TakeDamage(towerData.damage);
            // Implement slow effect here (e.g., reduce enemy speed for a duration)
            // For MVP, a simple debug log or temporary speed reduction can be used.
        }
    }
}
