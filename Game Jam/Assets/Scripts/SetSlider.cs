using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audiomixer;
public void SliderSet(float sliderVal){
        audiomixer.SetFloat("Volume", Mathf.Log10(sliderVal)*20);
    }
}
