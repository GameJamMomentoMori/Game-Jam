using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 6f;
    Transform player;
    public bool hasInteracted = false;
    public bool isRanged = false;
    public Transform interactionTransform;
    float distance;
    EnemyAIController enemyAI;
    CharStat enemyStats;
    PlayerStats playerStats;

    public virtual void Interact() {
        //This method is meant to be overwritten
        if (isRanged) {
            
            enemyStats.TakeDmg(playerStats.dmg.getVal() / 2);
            enemyAI.enemyDamaged();
            Debug.Log(transform.name + " took " + (playerStats.dmg.getVal()/4) + " damage!");
            isRanged = false;
            
                StartCoroutine(InteractTimer());
        } else {
            if (distance <= radius) {
                Debug.Log("Interacting with " + transform.name);
                enemyAI.enemyDamaged();
            
                enemyStats.TakeDmg(playerStats.dmg.getVal());
                Debug.Log(transform.name + " took " + playerStats.dmg.getVal() + " damage!");
                
                StartCoroutine(InteractTimer());
            }
        }
    }

    void Awake() {
        GameObject playerObj = GameObject.Find("FirstPersonPlayer");
        player = playerObj.GetComponent<Transform>();
        enemyAI = gameObject.GetComponent<EnemyAIController>();
        enemyStats = gameObject.GetComponent<CharStat>();
        playerStats = playerObj.GetComponent<PlayerStats>();
        interactionTransform = this.transform;
    }

    void Update() {
        //if (!hasInteracted) {
            distance = Vector3.Distance(player.position, interactionTransform.position);
           // }
       // }
    }

    void OnDrawGizmosSelected() {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    IEnumerator InteractTimer(){
        hasInteracted= true;
        yield return new WaitForSeconds(0.86f);
        hasInteracted = false;
    }
}
