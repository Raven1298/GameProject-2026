using System;
using System.Collections;
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

    private bool canDash = true;
    private bool isDashing;
    public float dashSpeed = 10f;
    public float dashTime = 0.1f;
    private float dashCooldown = 2.5f;


    // Update is called once per frame
    void Update(){

        if(isDashing){
            return;
        }


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
            //SoundManager.PlaySound(SoundType.movement, .2f);
        }
        
        //dashing
        if(Keyboard.current.kKey.wasPressedThisFrame && canDash && (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)){
            StartCoroutine(Dash());
        }

        if(Keyboard.current.kKey.wasPressedThisFrame && canDash && (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)){
            StartCoroutine(LDash());
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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashSpeed, 0f);
        yield return new WaitForSeconds(dashTime * Time.deltaTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private IEnumerator LDash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(-transform.localScale.x * dashSpeed, 0f);
        yield return new WaitForSeconds(dashTime * Time.deltaTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown * Time.deltaTime);
        canDash = true;
    }
}
