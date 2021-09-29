using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator blood;
    public GameObject fade;

    void Start()
    {
        StartCoroutine(DieAnimation());
    }

    // Update is called once per frame
    public IEnumerator DieAnimation(){
        //dead = true;
         yield return new WaitForSeconds(1f);
        blood.SetBool("DeathAnimation",true);
        yield return new WaitForSeconds(1f);
        fade.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
