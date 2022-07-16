using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 10.0f;
    public Colour colour;
    public float Speed = 2.0f;
    public float damage = 1.0f;
    public GameObject impactEffect;

    public Transform[] target;
    public float damping = 6.0f;

    public GameObject village; 

    private int current;


    public void findPath()
    {
        int i = 0;
        village = GameObject.FindGameObjectWithTag("Village");
        Debug.Log(village);
        GameObject[] points = GameObject.FindGameObjectsWithTag("EnemyPath");
        int len = points.Length;
        foreach (GameObject point in points)
        {
            GameObject pos = (GameObject.Find("EnemyPathPosition (" + i + ")"));
            target[i]= (pos.transform);
            i++;
            
        }
    }
   public void followPath()
    {
        if (transform.position != target[current].position)
        {
            var rotation = Quaternion.LookRotation(target[current].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, Speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else {
            current = (current + 1);
            if (current == target.Length)
            {
                village.GetComponent<Village>().villageHealth -= damage;
                GameObject effectIns  = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(effectIns, 2f);
                Destroy(gameObject);
            }
        } 

    }
    public void die()
    {
        Debug.Log("Bloody Hell!");
        Destroy(gameObject);
    }

    public void takeDamage(float damage)  {
        this.Health-=damage;
    }

    public void celebrate()
    {

    }

    public void Start()
    {
        findPath();
    }

    public void Update()
    {
        if (Health > 0)
        {
            followPath();
        } else 
        {
            die();
        }
    }
}