using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform m_target;

    public float speed = 70f;

    public int damage = 50;

    public float explosionRadius = 0f;
    public GameObject impactEffect;


    public void Seek(Transform _target)
    {
        m_target = _target;
    }

    
    void Update()
    {
        if (m_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = m_target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(m_target);
    }


    void HitTarget ()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(m_target);
        }

        Destroy(gameObject);
    }


    void Explode()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }


    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }        
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
