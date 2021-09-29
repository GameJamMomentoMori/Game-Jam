using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveCount : MonoBehaviour
{
    public TMP_Text wave;
    public static int waveNumber = 1;
    public Animator waveAnimator;
    public AudioSource w2;
    public AudioSource w4;
    public AudioSource w6;
    public AudioSource w8;
    public AudioSource w10;

    void Start()
    {
        //wave = GetComponent<Text>();
    }
    
    public void NextWave()
    {
        Animate();
        if(waveNumber == 2)
        w2.Play();
        if(waveNumber == 4)
        w4.Play();
        if(waveNumber == 6)
        w6.Play();
        if(waveNumber == 8)
        w8.Play();
        if(waveNumber == 10)
        w10.Play();
        waveNumber += 1;
        wave.text = waveNumber.ToString();
        
    }

    public void SetOne(){
        Animate();
        wave.text = waveNumber.ToString();
    }

    void Animate(){
        waveAnimator.Play("FadeOut");
    }
}
