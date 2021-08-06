using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float Defaultspeed = 3f;
    public float gravity = -30f;
    public float jumpHight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    float finalSpeed;

    // Update is called once per frame
    void Update()
    {
        //Sprint
        if (Input.GetButton("Shift"))
        {
            finalSpeed = Defaultspeed * 1.75f;
        }
        else
        {
            finalSpeed = Defaultspeed;
        }
        //Sprint

        //Gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //Gravity

        //Mouse Movement with Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * finalSpeed * Time.deltaTime);
        //Mouse Movement with Input

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
        }
        //Jump

        //Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        //Gravity

    }
}
