using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroll : MonoBehaviour
{
    public bool scroll;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scroll());
    }
    void Update(){
        if(scroll){
            transform.Translate(0,0.15f,0);
        }
    }

    // Update is called once per frame
    IEnumerator Scroll(){
        yield return new WaitForSeconds(22f);
        scroll = true;
    }
}
