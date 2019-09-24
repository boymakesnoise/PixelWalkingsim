using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator anim;
    
    public float walkSpeed = 1.2f;
    public float runSpeed = 7.5f;
    public float rotSpeed = 0.001f;

    void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        float speed = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
        
        if (controller.isGrounded) {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed, 0);

        //Gravity
        moveDirection.y -= 10f * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        anim.SetFloat("Speed", controller.velocity.magnitude);
    }
}
