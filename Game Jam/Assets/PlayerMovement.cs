using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jump = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //check if the player is on the ground to reset the gravity velocity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //apply gravity to the player object
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //gets the use input from the keyboard
        float PlayerX = Input.GetAxis("Horizontal");
        float PlayerZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * PlayerX + transform.forward * PlayerZ;

        //Moves the character the certain amount times the speed and time for FPS normalization
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
