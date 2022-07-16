using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private GameObject enemyHit;
    public float damage = 1;
    public float speed = 10f;
    public GameObject impactEffect;
    
    public void Seek(Transform t)
    {
        target = t;
    }
    
    void HitTarget(){
        GameObject effectIns  = (GameObject)Instantiate(impactEffect, target.position, transform.rotation);
        Destroy(effectIns, 2f);
        enemyHit = target.gameObject;
        enemyHit.GetComponent<Enemy>().takeDamage(damage);

        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
}
