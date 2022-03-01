using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    public float speed;

    CharacterController characterController;
    public Transform checkPoint;
    public LayerMask Ground;
    public float checkRadius=0.2f;
    public float hight = 15;

    public Vector3 velocity;
    public float gravity=-9.81f;
    public bool isGround;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {

        isGround = Physics.CheckSphere(checkPoint.position, checkRadius, Ground);
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 moveDirection = transform.right * x  + transform.forward * y;
        characterController.Move(moveDirection*speed*Time.deltaTime);

        if (Input.GetButton("Jump") && isGround)
        {
            velocity.y=Mathf.Sqrt(hight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
