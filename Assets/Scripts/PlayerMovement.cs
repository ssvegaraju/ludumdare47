using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpHeight = 5f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    
    public LayerMask groundMask;
    private bool isGrounded;
    private CharacterController controller;
    private float yVel;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && yVel < 0) {
            yVel = -2f;
        }
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }

        Vector3 move = transform.right * input.x + transform.forward * input.z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        yVel += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, yVel, 0) * Time.deltaTime);
    }

    void Jump() {
        yVel += Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
