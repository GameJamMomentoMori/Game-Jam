using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    Transform player;
    bool hasInteracted = false;
    public Transform interactionTransform;

    public virtual void Interact() {
        //This method is meant to be overwritten
        Debug.Log("Interacting with" + transform.name);
    }

    void Update() {
        if (!hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);

            if (distance <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
        
    }

    void OnDrawGizmosSelected() {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
