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

    void Start()
    {
        //wave = GetComponent<Text>();
    }
    
    public void NextWave()
    {
        Animate();
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
