using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public AudioSource diceImpact;

    public DiceType diceType;

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            diceImpact.Play();
         }
    }
        
}
