using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform m_target;
    Enemy m_targetEnemy;

    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    float m_fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turretSpeed = 10f;

    
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float m_shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy< m_shortestDistance)
            {
                m_shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy!= null && m_shortestDistance <= range)
        {
            m_target = nearestEnemy.transform;
            m_targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            m_target = null;
        }
    }


    void Update()
    {
        if (m_target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }                    
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (m_fireCountdown <= 0)
            {
                Shoot();
                m_fireCountdown = 1f / fireRate;
            }

            m_fireCountdown -= Time.deltaTime;
        }        
    }


    void LockOnTarget()
    {
        Vector3 dir = m_target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turretSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }


    void Laser()
    {
        m_targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        m_targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
            

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, m_target.position);

        Vector3 dir = firePoint.position - m_target.position;

        impactEffect.transform.position = m_target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }


    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(m_target);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
