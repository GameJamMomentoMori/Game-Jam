using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalVoiceLine : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource swipe;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LastVoiceLine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LastVoiceLine(){
        yield return new WaitForSeconds(8f);
        swipe.Play();
        yield return new WaitForSeconds(5f);
        audio.Play();
    }
}
