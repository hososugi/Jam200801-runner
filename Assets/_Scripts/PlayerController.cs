using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpForce = 5f;

    [SerializeField]
    private bool isMoving = true;
    [SerializeField]
    private bool isGrounded = false;

    private Rigidbody rigidBody;
    private Vector3 direction;
    private Vector3 movementForce;
    private Vector3 movementVelocity;


    void Start()
    {
        rigidBody        = GetComponent<Rigidbody>();
        direction        = Vector3.right;
        movementVelocity = direction * playerSpeed;
    }

    private void Update()
    {
        // Run forward.
        if (isMoving)
        {
            rigidBody.velocity = new Vector3(playerSpeed, rigidBody.velocity.y, 0);
        }

        // Changes the height position of the player.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            movementForce = Vector3.up * jumpForce;
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
}
