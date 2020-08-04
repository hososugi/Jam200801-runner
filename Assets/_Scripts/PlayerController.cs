using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isMoving = true;
    public bool isGrounded = false;
    public float playerSpeed = 5f;
    public float jumpHeight = 1f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // Direction
        Vector3 direction = Vector3.forward;
        Vector3 velocity = direction * playerSpeed;

        if (controller.isGrounded && !isGrounded)
            isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        if (isMoving)
        {
            Vector3 move = new Vector3(playerSpeed, 0, 0);
            controller.Move(move * Time.deltaTime);
            gameObject.transform.forward =  move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
