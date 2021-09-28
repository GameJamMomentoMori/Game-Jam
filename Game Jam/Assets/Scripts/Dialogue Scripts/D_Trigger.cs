using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<D_Manager>().StartDialogue(dialogue);
    }
}
