using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 6f;
    Transform player;
    public bool hasInteracted = false;
    public Transform interactionTransform;
    float distance;
    EnemyAIController enemyAI;

    public virtual void Interact() {
        //This method is meant to be overwritten
        if (distance <= radius) {
            Debug.Log("Interacting with " + transform.name);
            enemyAI.enemyDamaged();
            StartCoroutine(InteractTimer());
        }
    }

    void Awake() {
        GameObject playerObj = GameObject.Find("FirstPersonPlayer");
        player = playerObj.GetComponent<Transform>();
        enemyAI = gameObject.GetComponent<EnemyAIController>();
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
        yield return new WaitForSeconds(0.65f);
        hasInteracted = false;
    }
}
