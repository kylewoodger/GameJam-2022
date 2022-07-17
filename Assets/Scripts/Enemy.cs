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
    public AudioSource impactSound;

    public  ArrayList target = new ArrayList();
    public float damping = 6.0f;

    public GameObject village; 

    private int current = 0;


    public void findPath()
    {
        int i = 0;
        village = GameObject.FindGameObjectWithTag("Village");
        GameObject[] points = GameObject.FindGameObjectsWithTag("EnemyPath");
        int len = points.Length;
        foreach (GameObject point in points)
        {
            GameObject pos = (GameObject.Find("EnemyPathPosition (" + i + ")"));
            target.Add(pos.transform);
            i++;
            
        }
    }
   public void followPath()
    {
        var targetPos = (Transform)target[current];
        if (transform.position != targetPos.position)
        {
            var rotation = Quaternion.LookRotation(targetPos.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            Vector3 pos = Vector3.MoveTowards(transform.position, targetPos.position, Speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else {
            current = (current + 1);
            if (current == target.Count)
            {
                village.GetComponent<Village>().villageHealth -= damage;
                impactSound.Play();
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