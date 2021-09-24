using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton

    public static EnemyManager instance;

    void Awake() {
        instance = this;
    }

    #endregion

    public GameObject enemy;

    public void KillEnemy () {
        //plays dealth animation

        //removes from scene
        EnemyDeath();
    }

    private void EnemyDeath(){
        Destroy(this.gameObject,1f);
        Debug.Log(enemy + " dead.");
    }
}
