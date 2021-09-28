using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCount : MonoBehaviour
{
    Text wave;
    public static int waveNumber;

    void Start()
    {
        wave = GetComponent<Text>();
    }

    public void NextWave()
    {
        waveNumber += 1;
        wave.text = "Wave #" + waveNumber;
    }
}
