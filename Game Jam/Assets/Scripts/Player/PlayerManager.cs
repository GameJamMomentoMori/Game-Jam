using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Animator blood;
    public GameObject fade;

    #region Singleton

    public static PlayerManager instance;

    void Awake() {
        instance = this;
    }

    #endregion

    public GameObject player;

    public void KillPlayer () {
        //restarts scene
        StartCoroutine(DieAnimation());
       
    }

    public IEnumerator DieAnimation(){
        //dead = true;
        yield return new WaitForSeconds(1f);
        blood.SetBool("DeathAnimation",true);
        yield return new WaitForSeconds(1f);
        fade.SetActive(true);
        //yield return new WaitForSeconds(1f);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
