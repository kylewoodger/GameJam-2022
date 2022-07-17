using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    
    public float fireRate;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float turnSpeed = 10;
    public float sightRange;
    public Transform target;
    public BulletModifiers bulletModifiers;
    public TowerType towerType;
    public string enemyTag = "Enemy";
    
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.gameObject.transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }


    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        // Look at target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; 
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    
        // Shoot at target
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = 100000000;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= sightRange)
        {
            target = nearestEnemy.transform;
        } else 
        {
            target = null;
        }

    }

    // Draw range sphere
    void OnDrawGizmosSelected ()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
