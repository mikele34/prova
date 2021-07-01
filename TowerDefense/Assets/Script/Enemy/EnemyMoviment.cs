using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMoviment : MonoBehaviour
{
    Transform m_target;
    int m_wavepointIndex = 0;

    Enemy m_enemy;


    void Start()
    {
        m_enemy = GetComponent<Enemy>();
        m_target = Waypoints.points[0];        
    }


    void Update()
    {
        Vector3 dir = m_target.position - transform.position;
        transform.Translate(dir.normalized * m_enemy.speed * Time.deltaTime, Space.World);

        Quaternion lookrotation = Quaternion.LookRotation(dir.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookrotation, 8.0f * Time.deltaTime);


        if (Vector3.Distance(transform.position, m_target.position) <= 0.2f)
        {
            GetNextWaypoint();
            return;
        }

        m_enemy.speed = m_enemy.startSpeed;
    }


    void GetNextWaypoint()
    {
        if (m_wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        m_wavepointIndex++;
        m_target = Waypoints.points[m_wavepointIndex];
    }


    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
