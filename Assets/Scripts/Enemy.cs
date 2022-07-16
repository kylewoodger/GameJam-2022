using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 10.0f;
    public Colour colour;
    public float Speed = 2.0f;

    public Transform[] target;
    public float damping = 6.0f;

    private int current;


    void followPath()
    {
        if (transform.position != target[current].position)
        {
            var rotation = Quaternion.LookRotation(target[current].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, Speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current = (current + 1) % target.Length;

    }
    void die()
    {

    }
    void celebrate()
    {

    }

    void Update()
    {
        if (Health > 0)
        {
            followPath();
        }
    }
}