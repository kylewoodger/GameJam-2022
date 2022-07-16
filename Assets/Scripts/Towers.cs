using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    
    public float fireRate;
    public float sightRange;
    public Transform target;
    public BulletModifiers bulletModifiers;
    public TowerType towerType;
    public string enemyTag = "Enemy";
    
    void Aim() {

    }

    void Shoot()
    {

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

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles; 
        transform.rotation = Quaternion.Euler(0f, rotation.y, 90f);
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
        }
    }

    // Draw range sphere
    void OnDrawGizmosSelected ()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
