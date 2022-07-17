using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource soundtrack;
    public AudioSource laser;
    public AudioSource explosion;
    public AudioSource rubber;
    public AudioSource diceroll1;
    public AudioSource diceroll2;
    public AudioSource diceImpact;
    

    public void PlaySoundtrack() {
        soundtrack.Play();
    }

    
}
