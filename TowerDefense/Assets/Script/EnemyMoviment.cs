using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMoviment : MonoBehaviour
{
    Transform target;
    int wavepointIndex = 0;

    Enemy enemy;

    float degrees;

    Vector3 to;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];        
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        Quaternion lookrotation = Quaternion.LookRotation(dir.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookrotation, 8.0f * Time.deltaTime);


        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
            return;
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
