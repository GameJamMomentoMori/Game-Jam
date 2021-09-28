using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
//[SerializeField] GameObject FadeObject;
    [SerializeField] FadeTransition fadescript;
    public AudioSource hover;
    public AudioSource press;

    public void PlayGame()
    {
        StartCoroutine(Play());
    Press();
        
    }
    public void Hover(){
        hover.Play();
    }
    
     public void Press(){
        press.Play();
    }

    public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    public IEnumerator Play(){
        StartCoroutine(fadescript.FadeIn());
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator Quit(){
        Press();
        StartCoroutine(fadescript.FadeOut());
        yield return new WaitForSeconds(1f);
        Debug.Log("Quit");
        Application.Quit();
    }
}
