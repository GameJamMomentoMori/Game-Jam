using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton

    public static EnemyManager instance;
    EnemyAIController enemyAI;

    void Awake() {
        instance = this;
        enemyAI = gameObject.GetComponent<EnemyAIController>();
    }

    #endregion

    public GameObject enemy;

    public void KillEnemy () {
        //plays dealth animation
        enemyAI.Death();
        //removes from scene
        EnemyDeath();
    }

    private void EnemyDeath(){
        Destroy(this.gameObject,3f);
        Debug.Log(enemy + " dead.");
    }
}
