using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed; // This will come from EnemyData

    private int _waypointIndex = 0;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        if (_enemy == null)
        {
            Debug.LogError("EnemyMovement requires an Enemy component on the same GameObject.", this);
            enabled = false;
            return;
        }
        speed = _enemy.enemyData.speed; // Get speed from EnemyData
    }

    private void Start()
    {
        if (waypoints == null || waypoints.Count == 0)
        {
            Debug.LogError("Waypoints not assigned for enemy movement.", this);
            enabled = false;
            return;
        }
        transform.position = waypoints[_waypointIndex].position;
    }

    private void Update()
    {
        if (_waypointIndex < waypoints.Count)
        {
            MoveToWaypoint();
        }
        else
        {
            _enemy.ReachCore(); // Enemy reached the end of the path
        }
    }

    private void MoveToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[_waypointIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[_waypointIndex].position) < 0.1f)
        {
            _waypointIndex++;
        }
    }
}
