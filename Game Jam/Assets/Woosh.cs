using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woosh : MonoBehaviour
{
    public AudioSource explosion;
    public void Awake(){
        explosion.Play();
    }
}
