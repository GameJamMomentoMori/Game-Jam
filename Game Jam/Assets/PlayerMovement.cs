using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        float PlayerX = Input.GetAxis("Horizontal");
        float PlayerZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * PlayerX + transform.forward * PlayerZ;

        controller.Move(move * speed * Time.deltaTime);
    }
}
