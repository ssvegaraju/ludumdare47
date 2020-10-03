using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpHeight = 15f;
    public float rotateSpeed = 120f;
    public float decelerationAmount = 2f;

    private Rigidbody rigid;
    private float yVel;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }

        rigid.velocity += input.normalized;
        yVel = rigid.velocity.y;
        yVel += Physics.gravity.y * Time.deltaTime;
        rigid.velocity = Vector3.Lerp(rigid.velocity, Vector3.up * yVel, decelerationAmount * Time.deltaTime);
    }

    void Jump() {
        rigid.AddForce(Vector3.up * jumpHeight);
    }
}
