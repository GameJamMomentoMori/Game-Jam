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
        int b = SceneManager.GetActiveScene().buildIndex;
        if(b == 1){
            StartCoroutine(FadeOut());
        }
    }
    public IEnumerator FadeIn(){
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(true);
    }
    public IEnumerator FadeOut(){
        this.gameObject.SetActive(true);
        _animator.Play("FadeOut");
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }
}
