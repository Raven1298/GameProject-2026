using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class playerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public Rigidbody2D rb;
    public float speed = 5f;
    public float runSpeed = 10f;
    public float currentSpeed;
    public float jumpForce;
    public Transform GroundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;


    // Update is called once per frame
    void Update(){

        if (Keyboard.current == null){
            return;
        }
        //Movement
        Vector3 xMovement = Vector3.zero;
        currentSpeed = speed;

        if (Keyboard.current.shiftKey.isPressed){
            currentSpeed = runSpeed;
        }

        if (Keyboard.current != null){
            if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed){
                xMovement.x += 1;
            }

            if(Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed){
                xMovement.x -=1;
            }

            xMovement = xMovement.normalized * Time.deltaTime * currentSpeed;

            transform.position += new Vector3 (xMovement.x, 0, 0);
            
        }

        //Jumping
        if (Keyboard.current.spaceKey.wasPressedThisFrame){
            if(isGrounded()){
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }

        bool isGrounded()
        {
            return Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, groundLayer);
        }
    }
}
