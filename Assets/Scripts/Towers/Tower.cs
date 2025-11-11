using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData towerData;
    protected Enemy currentTarget;
    protected float attackCooldown;

    private void Awake()
    {
        if (towerData == null)
        {
            Debug.LogError("TowerData is not assigned to " + gameObject.name, this);
            enabled = false;
            return;
        }
        attackCooldown = 1f / towerData.attackSpeed;
    }

    private void Update()
    {
        if (currentTarget == null || !currentTarget.gameObject.activeSelf || Vector3.Distance(transform.position, currentTarget.transform.position) > towerData.range)
        {
            FindTarget();
        }

        if (currentTarget != null)
        {
            // Look at target (optional, for visual)
            // Vector3 direction = currentTarget.transform.position - transform.position;
            // Quaternion lookRotation = Quaternion.LookRotation(direction);
            // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                Attack();
                attackCooldown = 1f / towerData.attackSpeed;
            }
        }
    }

    protected virtual void FindTarget()
    {
        // Simple targeting: find closest enemy
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Enemy nearestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= towerData.range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        currentTarget = nearestEnemy;
    }

    protected virtual void Attack()
    {
        if (currentTarget != null)
        {
            Debug.Log($"{towerData.towerName} attacking {currentTarget.name} for {towerData.damage} damage.");
            currentTarget.TakeDamage(towerData.damage);
        }
    }
}
