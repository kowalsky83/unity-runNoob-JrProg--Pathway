using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private Transform groundCheckPoint, groundCheckPoint2;
    private float checkRadius = 0.27f;

    // Movement
    [SerializeField] private float jumpSpeed = 15.0f;
    private float gravity = 1.0f;
    private float fallMultiplier = 5.0f;

    //Verifications
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded = true;
    public float groundLength = 1.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer) || Physics2D.OverlapCircle(groundCheckPoint2.position, checkRadius, groundLayer);
        if(Input.GetButtonDown("Jump") && isGrounded){
            Jump(); // ABSTRACTION
        }
    }

    void FixedUpdate() {
        ModifyPhysics(); // ABSTRACTION
    }

    void Jump(){
        animator.SetBool("isGrounded",false);
        rb.velocity = new Vector2(rb.velocity.x,0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    void ModifyPhysics(){
        if(!isGrounded){
            //Falling
            if(rb.velocity.y < 0){
                rb.gravityScale = gravity * fallMultiplier;
            }else if(rb.velocity.y > 0 && !Input.GetButton("Jump")){
                rb.gravityScale = gravity * (fallMultiplier/2);
            }
            animator.SetBool("isGrounded",false);
            animator.SetBool("isFalling",true);
        }else{
            rb.gravityScale = gravity;
            animator.SetBool("isGrounded",true);
            animator.SetBool("isFalling",false);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(groundCheckPoint.position, groundCheckPoint.position + Vector3.down * checkRadius);
        Gizmos.DrawLine(groundCheckPoint2.position, groundCheckPoint2.position + Vector3.down * checkRadius);
    }
}
