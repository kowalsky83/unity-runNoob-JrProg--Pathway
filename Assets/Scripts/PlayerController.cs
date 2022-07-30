using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Fisicas basicas
    private float jumpforce = 15.0f;
    private Rigidbody2D rb;

    //Animacion y render
    private Animator anim;

    //Jump Control
    [SerializeField] private Transform groundCheckPoint, groundCheckPoint2;
    private float checkRadius = 0.27f;//0.4f;//
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded = false;
    public float hangTime = 0.2f;
    private float hangCounter;
    public float jumpBufferLength = 0.1f;
    private float jumpBufferCount;
    private float gravity = 1;
    private float fallMultiplier = 5.0f;//2.5f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, whatIsGround) || Physics2D.OverlapCircle(groundCheckPoint2.position, checkRadius, whatIsGround);
        
        manageHangTime(isGrounded);
        manageJumpBuffer();
        jump();
    }

    private void manageHangTime(bool isGrounded){
        if(isGrounded){
            hangCounter = hangTime;
            anim.SetBool("isGrounded",true);
            anim.SetBool("isFalling",false);
            anim.SetBool("isJumping",false);
        }else{
            hangCounter -= Time.deltaTime;
            anim.SetBool("isGrounded",false);
        }
    }

    private void manageJumpBuffer(){
        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLength;
        }else{
            jumpBufferCount -= Time.deltaTime;
        }
    }

    private void jump(){
        if (jumpBufferCount>=0 && hangCounter>0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                jumpBufferCount = 0;
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            }

        if(rb.velocity.y>0){
                rb.gravityScale = gravity;
                anim.SetBool("isJumping",true);
                anim.SetBool("isFalling",false);
            }else if(rb.velocity.y<0){
                rb.gravityScale = gravity * fallMultiplier;
                anim.SetBool("isJumping",false);
                anim.SetBool("isFalling",true);
            }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(groundCheckPoint.position, groundCheckPoint.position + Vector3.down * checkRadius);
        Gizmos.DrawLine(groundCheckPoint2.position, groundCheckPoint2.position + Vector3.down * checkRadius);
    }

}
