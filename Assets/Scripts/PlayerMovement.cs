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
    public float respawnY = 10f;
    public bool debugMode = false;
    private bool isGrounded;
    private CharacterController controller;
    private float yVel;
    private Vector3 checkpoint;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        checkpoint = transform.position;
        AudioManager.instance.Play("gameLoop");
        AudioManager.instance.Play("footsteps");
    }

    void Update()
    {
        bool prevGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!prevGrounded && isGrounded != prevGrounded) {
            AudioManager.instance.Play("land");
        }

        if (isGrounded && yVel < 0) {
            yVel = -2f;
        }
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (isGrounded && input != Vector3.zero) {
            AudioManager.instance.ChangeSoundVolume("footsteps", 0.4f);
        } else {
            AudioManager.instance.ChangeSoundVolume("footsteps", 0f);
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
            AudioManager.instance.Play("jumpGrunt");
        }
        DebugMode();

        Vector3 move = transform.right * input.x + transform.forward * input.z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        yVel += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, yVel, 0) * Time.deltaTime);

        RespawnIfNecessary();
    }

    void DebugMode() {
        if (Input.GetButtonDown("Jump") && debugMode) {
            Jump();
        }
    }

    void Jump() {
        yVel += Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    void RespawnIfNecessary() {
        if (transform.position.y < checkpoint.y - respawnY) {
            transform.position = checkpoint;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Checkpoint" && other.transform.GetChild(0).position.y > checkpoint.y) {
            checkpoint = other.transform.GetChild(0).position;
            AudioManager.instance.Play("hooray");
        } else if (other.gameObject.tag == "Goal") {
            GetComponent<Timer>().StopTimer();
            Application.Quit();
        }
    }
}
