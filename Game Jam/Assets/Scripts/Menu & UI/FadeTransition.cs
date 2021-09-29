using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{
    // Start is called before the first frame updat
    // Update is called once per frame
    [SerializeField] Animator _animator;
    void Start(){
            StartCoroutine(FadeIn());
        
    }
    public IEnumerator FadeIn(){
        _animator.Play("FadeIn");
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
        
    }
    public IEnumerator FadeOut(){
        this.gameObject.SetActive(true);
        _animator.Play("FadeOut");
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
        
        
    }
}
