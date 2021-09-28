using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveCount : MonoBehaviour
{
    public TMP_Text wave;
    public static int waveNumber;

    void Start()
    {
        //wave = GetComponent<Text>();
    }

    public void NextWave()
    {
        waveNumber += 1;
        wave.text = waveNumber.ToString();
    }
}
